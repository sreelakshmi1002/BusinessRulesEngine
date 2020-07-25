using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Interfaces
{
    interface IProcessOrder
    {
        PaymentResult ProcessPayment(ProductInfo model);
    }
}
