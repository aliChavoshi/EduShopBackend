using System.Runtime.Serialization;

namespace Domain.Enums;

public enum OrderStatus
{
    [EnumMember(Value = "Pending")] Pending = 1,
    [EnumMember(Value = "PaymentSuccess")] PaymentSuccess,
    [EnumMember(Value = "PaymentFailed")] PaymentFailed,
    [EnumMember(Value = "Shipped")] Shipped,
    [EnumMember(Value = "Cancelled")] Cancelled
}