namespace KarlArt.Core.Application.Common.Interfaces.Services;
public interface IPaymentService
{
    Task<bool> PayAsync(Payment payment);
}