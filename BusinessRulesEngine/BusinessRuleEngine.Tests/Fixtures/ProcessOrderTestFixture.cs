using BusinessRuleEngine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Tests.Fixtures
{
    [TestFixture]
    public class ProcessOrderTestFixture 
    {
        List<ProductInfo> products;
        List<MemeberShipDetails> Members;
        public ProcessOrderTestFixture()
        {
            products = GetProductInfo();

        }

        public List<ProductInfo> GetProductInfo()
        {
            List<ProductInfo> details = new List<ProductInfo>();
            details.Add(new ProductInfo
            {
                ProductType = ProductTypes.BOOK,
                Name = "Book Test 1",
                Price = 150,
                Quantity = 5

            });

            details.Add(new ProductInfo
            {
                ProductType = ProductTypes.VIDEO,
                Name = "Video Test 1",
                Description = "learning to ski",
                Price = 150,
                Quantity = 5

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

        public List<MemeberShipDetails> GetMembers()
        {
            List<MemeberShipDetails> details = new List<MemeberShipDetails>();
            details.Add(new MemeberShipDetails
            {
                MemberName = "User 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                MemberShipType = MemberShipType.ACTIVATION
            });

            details.Add(new MemeberShipDetails
            {
                MemberName = "User 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                MemberShipType = MemberShipType.UPGRADE
            });

            return details;
        }

    }
}
