namespace Application.Contracts;

public interface ICurrentUserService
{
    string UserId { get; }
    string PhoneNumber { get; }
}