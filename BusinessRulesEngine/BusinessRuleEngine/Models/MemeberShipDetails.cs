using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Models
{
    public class MemeberShipDetails
    {
        public string MemberName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MemberShipType SubscriptionType { get; set; }
    }
}
