﻿using BusinessRuleEngine.Common;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Services
{
    public class BookPayment : ProcessOrderFactory<ProductInfo>
    {
        protected override PaymentResult ProcessPayment(ProductInfo model)
        {
            model.RoyaltyDepartmentPrice = model.Quantity * model.Price * model.Commission;

            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Royalty payment slip created with Amount -" + model.RoyaltyDepartmentPrice,
                };
            }
            else
            {
                throw new InvalidOperationException("Book Name is missing");
            }
        }
    }
}
