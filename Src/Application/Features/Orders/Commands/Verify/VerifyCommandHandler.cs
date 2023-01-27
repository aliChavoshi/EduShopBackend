using Application.Contracts;
using Domain.Entities.Order;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZarinpalSandbox;

namespace Application.Features.Orders.Commands.Verify;

public class VerifyCommand : IRequest<string>
{
    public string Authority { get; set; }
    public string Status { get; set; }

    public VerifyCommand(string authority, string status)
    {
        Authority = authority;
        Status = status;
    }
}

public class VerifyCommandHandler : IRequestHandler<VerifyCommand, string>
{
    private readonly IUnitOWork _uow;
    private readonly IConfiguration _configuration;

    public VerifyCommandHandler(IUnitOWork uow, IConfiguration configuration)
    {
        _uow = uow;
        _configuration = configuration;
    }

    public async Task<string> Handle(VerifyCommand request, CancellationToken cancellationToken)
    {
        //1. order : authority
        var order = await _uow.Context.Set<Order>()
            .Include(x => x.DeliveryMethod)
            .Where(x => x.Authority == request.Authority)
            .SingleOrDefaultAsync(cancellationToken);
        if (order == null) throw new BadRequestEntityException("سفارش شما یافت نشد مجدد تلاش کنید");
        //2. portal : orderId
        var portal = await _uow.Repository<Portal>().Where(x => x.OrderId == order.Id)
            .SingleOrDefaultAsync(cancellationToken);
        if (portal == null) throw new BadRequestEntityException("پرداخت شما مشکل دارد لطفا با پشتیبانی تماس بگیرید");
        //3. cancel submitted
        if (request.Status != "OK")
        {
            //update order
            order.OrderStatus = OrderStatus.Cancelled;
            await _uow.Repository<Order>().UpdateAsync(order);
            //update portal
            portal.Status = PaymentDataStatus.Canceled;
            await _uow.Repository<Portal>().UpdateAsync(portal);
            //save changes
            await _uow.Save(cancellationToken);
            return _configuration["Order:CallBackCanceled"];
        }

        //4. payment verification=> get-way
        var amount = (int)order.GetOriginalTotal();
        var payment = new Payment(amount);
        var result = await payment.Verification(request.Authority); //status = 100 => success
        if (result.Status == 100)
        {
            //success
            //update order
            order.IsFinally = true;
            order.OrderStatus = OrderStatus.Pending;
            await _uow.Repository<Order>().UpdateAsync(order);
            //update portal
            portal.ReferenceId = result.RefId.ToString();
            portal.Status = PaymentDataStatus.Success;
            await _uow.Repository<Portal>().UpdateAsync(portal);
            await _uow.Save(cancellationToken);
            //redirect
            return _configuration["Order:CallBackSuccess"];
        }

        //failed , unsuccessful
        //update order
        order.OrderStatus = OrderStatus.PaymentFailed;
        await _uow.Repository<Order>().UpdateAsync(order);
        //update portal 
        portal.Status = PaymentDataStatus.Failed;
        await _uow.Repository<Portal>().UpdateAsync(portal);
        await _uow.Save(cancellationToken);
        return _configuration["Order:CallBackFailed"];
    }
}