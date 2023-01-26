using Openpay;
using OPEntities = Openpay.Entities;
using Openpay.Entities.Request;

namespace KarlArt.Core.Infrastructure.Services;
public class OpenPayService : IPaymentService
{
    private readonly OpenpayAPI _api;
    public OpenPayService(OpenpayAPI api)
    {
        _api = api;
    }

    public Task<bool> PayAsync(Payment payment)
    {
        OPEntities.Customer customer = _api.CustomerService.Create(new OPEntities.Customer()
        {
            Name = payment.Customer.Name,
            LastName = payment.Customer.LastName,
            Email = payment.Customer.Email,
            PhoneNumber = payment.Customer.Phone,
            Address = new OPEntities.Address()
            {
                Line1 = payment.Customer.Address,
                City = payment.Customer.City,
                State = payment.Customer.State,
                PostalCode = payment.Customer.PostalCode,
                CountryCode = payment.Customer.CountryCode
            }
        }); 

        OPEntities.Card card = _api.CardService.Create(customer.Id, new OPEntities.Card()
        {
            HolderName = payment.Card.HolderName,
            CardNumber = payment.Card.CardNumber,
            ExpirationMonth = payment.Card.ExpirationMonth,
            ExpirationYear = payment.Card.ExpirationYear,
            Cvv2 = payment.Card.Cvv2
        });

        OPEntities.Charge charge = _api.ChargeService.Create(new ChargeRequest()
        {
            Method = "card",
            Card = card,
            Amount = payment.Amount,
            Description = payment.Description,
            OrderId = payment.OrderId.ToString(),
            Customer = customer
        });

        return Task.FromResult(charge.Status == "completed");
    }
}