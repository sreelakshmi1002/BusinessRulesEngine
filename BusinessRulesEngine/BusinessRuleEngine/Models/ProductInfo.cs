using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Models
{
    public class ProductInfo : Product
    {
        public DateTime PackagingDate { get; set; }
        public PaymentType PaymentOptions { get; set; }
        public double Commission { get; set; }
        public string AgentName { get; set; }
    }
}
