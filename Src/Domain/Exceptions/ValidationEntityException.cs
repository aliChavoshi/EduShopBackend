namespace Domain.Exceptions;

public class ValidationEntityException : BaseException
{
    public ValidationEntityException(List<string> messages) : base(messages)
    {
    }

    public ValidationEntityException(string message) : base(message)
    {
    }

    public ValidationEntityException() : base("خطایی رخ داده است لطفا مجدد تلاش کنید ")
    {
    }
}