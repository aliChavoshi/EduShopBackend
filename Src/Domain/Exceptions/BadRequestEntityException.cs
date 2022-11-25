namespace Domain.Exceptions;

public class BadRequestEntityException : BaseException
{
    public BadRequestEntityException(List<string> messages) : base(messages)
    {
    }

    public BadRequestEntityException(string message) : base(message)
    {
    }

    public BadRequestEntityException() : base("خطایی رخ داده است لطفا مجدد تلاش کنید")
    {

    }
}