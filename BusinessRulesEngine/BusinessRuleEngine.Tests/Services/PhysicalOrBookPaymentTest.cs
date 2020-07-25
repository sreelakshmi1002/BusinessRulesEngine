using BusinessRuleEngine.Common;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Tests.Fixtures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleEngine.Tests.Services
{
    public class PhysicalOrBookPaymentTest : ProcessOrderTestFixture
    {
        IProcessOrder OrderProcess;

        [Test]
        public void When_I_Pass_Valid_PhysicalProduct_Order_it_should_process()
        {
            //arrange
            var physcialProduct = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.BOOKORPHYSICAL).FirstOrDefault();

            double Commission = (physcialProduct.Quantity * physcialProduct.Price) / 0.20;

            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.BOOKORPHYSICAL);
            string message = "Commision paid to agent -" + Commission;

            //act
            var result = OrderProcess.ProcessPayment(physcialProduct);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(message, result.Message);


        }

        [Test]
        public void ProcessOrder_PhysicalProduct_Name_Empty_Test()
        {

            //arrange
            var product = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.BOOKORPHYSICAL).FirstOrDefault();
            product.AgentName = string.Empty;
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.BOOKORPHYSICAL);

            //assert
            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcess.ProcessPayment(product));
            Assert.That(ex.Message, Is.EqualTo("Agent Name is missing"));

        }
    }
}
