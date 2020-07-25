using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Services
{
    public class BookPayment
    {
        public PaymentResult ProcessOrder(ProductInfo model)
        {
            model.RoyaltyDepartmentPrice = model.Quantity * model.Price * model.Commission;

            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Royalty payment slip created with Amount - " + model.RoyaltyDepartmentPrice,
                };
            }
            else
            {
                throw new InvalidOperationException("Book Name is missing");
            }
        }
    }
}
