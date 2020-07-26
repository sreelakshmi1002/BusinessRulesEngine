using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Models;
using BusinessRuleEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Common
{
    //abstract factory pattern
    public abstract class ProcessOrderFactory<TModel> : IProcessOrder
    {
        public PaymentResult ProcessPayment<T>(T model)
        {
            return ProcessPayment((TModel)(object)model);
        }
        protected abstract PaymentResult ProcessPayment(TModel model);

    }
}
