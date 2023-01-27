using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Order;

namespace Application.Dtos.OrderDto;

public class OrderItemDto : IMapFrom<OrderItem>
{
    //child
    public int ProductItemId { get; set; }
    public string ProductName { get; set; }
    public string ProductTypeName { get; set; }
    public string ProductBrandName { get; set; }

    public string PictureUrl { get; set; }

    //root
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderItem, OrderItemDto>()
            .ForMember(x => x.ProductTypeName,
                c => c.MapFrom(v => v.ItemOrdered.ProductTypeName))
            .ForMember(x => x.ProductName,
                c => c.MapFrom(v => v.ItemOrdered.ProductName))
            .ForMember(x => x.ProductItemId,
                c => c.MapFrom(v => v.ItemOrdered.ProductItemId))
            .ForMember(x => x.ProductBrandName
                , c => c.MapFrom(v => v.ItemOrdered.ProductBrandName))
            //TODO : add picture url with port and i use resolver map
            .ForMember(x => x.PictureUrl,
                c => c.MapFrom(v => v.ItemOrdered.PictureUrl));
    }
}