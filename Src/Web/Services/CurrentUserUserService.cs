using System.Runtime.InteropServices;
using Application.Contracts;
using Web.Extensions;

namespace Web.Services;

public class CurrentUserUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string UserId => _contextAccessor?.HttpContext?.User?.GetUserId() ?? string.Empty;
    public string PhoneNumber => _contextAccessor?.HttpContext?.User?.GetPhoneNumber() ?? String.Empty;
}