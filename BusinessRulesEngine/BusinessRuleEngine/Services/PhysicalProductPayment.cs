using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Services
{
    public class PhysicalProductPayment
    {
        public PaymentResult ProcessOrder(ProductInfo model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Packing slip created for physical product",
                };
            }
            else
            {
                throw new InvalidOperationException("Product Name is missing");
            }
        }
    }
}
