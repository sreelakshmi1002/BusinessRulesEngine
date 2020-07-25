using BusinessRuleEngine.Models;

namespace BusinessRuleEngine.Interfaces
{
    public interface IMemberShipPayment
    {
        PaymentResult ProcessPayment(MemeberShipDetails model);
    }
}