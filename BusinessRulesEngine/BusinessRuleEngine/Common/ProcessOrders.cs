using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Models;
using BusinessRuleEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Common
{
    //Factory Pattern
    public class ProcessOrders
    {
        public static IProcessOrder GetPaymentMethod(PaymentType type)
        {
            IProcessOrder _processOrder = null;
            switch (type)
            {
                case PaymentType.PHYSICAL_PRODUCT:
                    _processOrder = new PhysicalProductPayment();
                    break;
                case PaymentType.BOOK:
                    _processOrder = new BookPayment();
                    break;
                case PaymentType.BOOKORPHYSICAL:
                    _processOrder = new PhysicalorBookPayment();
                    break;
                case PaymentType.VIDEO:
                    _processOrder = new VideoPayment();
                    break;
                case PaymentType.MEMBERSHIP:
                    _processOrder = new MemberShipPayment();
                    break;
                default:
                    break;
            }
            return _processOrder;
        }
    }
}
