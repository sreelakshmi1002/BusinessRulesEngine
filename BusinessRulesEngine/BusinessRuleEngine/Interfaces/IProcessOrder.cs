using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Interfaces
{
    public interface IProcessOrder
    {
        PaymentResult ProcessPayment<T>(T model);
    }
}
