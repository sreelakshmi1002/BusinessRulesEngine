using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRulesEngine.UI
{
    public static class SampleInput
    {
        private static List<ProductInfo> GetProducts()
        {
            List<ProductInfo> details = new List<ProductInfo>();
            details.Add(new ProductInfo
            {
                ProductType = ProductTypes.BOOK,
                Name = "Book Test 1",
                Price = 150,
                Quantity = 5,
                RoyaltyDepartmentPrice = 10,
                Commission = 15,
                Description = "Test Description"

            });

            details.Add(new ProductInfo
            {
                ProductType = ProductTypes.VIDEO,
                Name = "Video Test 1",
                Description = "learning to ski",
                Price = 150,
                Quantity = 5,
                Commission = 15,

            });

            details.Add(new ProductInfo
            {
                ProductType = ProductTypes.PHYSICAL_PRODUCT,
                AgentName = "Agent 001",
                Commission = 10,
                Name = "Physical Product Test 1",
                Description = "learning to ski",
                Price = 150,
                Quantity = 5

            });
            details.Add(new ProductInfo
            {
                ProductType = ProductTypes.BOOKORPHYSICAL,
                AgentName = "Agent 001",
                Name = "Physical or booking Product Test 1",
                Price = 150,
                Quantity = 5
            });


            return details;
        }

        private static List<MemeberShipDetails> GetMembers()
        {
            List<MemeberShipDetails> details = new List<MemeberShipDetails>();
            details.Add(new MemeberShipDetails
            {
                MemberName = "Member 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                MemberShipType = MemberShipType.ACTIVATION
            });

            details.Add(new MemeberShipDetails
            {
                MemberName = "Member 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                MemberShipType = MemberShipType.UPGRADE
            });

            return details;
        }


        public static ProductInfo GetSampleDataForOrder(PaymentType options)//, int subscription = 0)
        {
            ProductInfo data = null;

            switch (options)
            {
                case PaymentType.PHYSICAL_PRODUCT:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.PHYSICAL_PRODUCT).FirstOrDefault();
                    break;
                case PaymentType.BOOK:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.BOOK).FirstOrDefault();
                    break;
                case PaymentType.BOOKORPHYSICAL:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.BOOKORPHYSICAL).FirstOrDefault();
                    break;
                case PaymentType.VIDEO:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.VIDEO).FirstOrDefault();
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }

        public static MemeberShipDetails GetSampleDataMember(int memberShipType = 0)
        {
            MemeberShipDetails memberData = null;
            memberData = GetMembers().Where(x => x.MemberShipType == (MemberShipType)memberShipType).FirstOrDefault();
            return memberData;
        }

    }
}
