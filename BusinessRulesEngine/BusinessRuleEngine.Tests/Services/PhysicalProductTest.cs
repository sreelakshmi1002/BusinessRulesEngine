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
    public class PhysicalProductTest: ProcessOrderTestFixture
    {
        IProcessOrder OrderProcess;

        [Test]
        public void When_I_Pass_Valid_PhysicalProduct_Order_it_should_process()
        {
            //arrange
            var physcialProduct = GetProductInfo().Where(x => x.ProductType  == Models.ProductTypes.PHYSICAL_PRODUCT).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.PHYSICAL_PRODUCT);


            //act
            var result = OrderProcess.ProcessPayment(physcialProduct);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Packing slip for shipping generated for physical product", result.Message);


        }

        [Test]
        public void ProcessOrder_PhysicalProduct_Name_Empty_Test()
        {

            //arrange
            var product = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.PHYSICAL_PRODUCT).FirstOrDefault();
            product.Name = string.Empty;
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.PHYSICAL_PRODUCT);

            //assert
            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcess.ProcessPayment(product));
            Assert.That(ex.Message, Is.EqualTo("Physical Product Name is missing"));

        }
    }
}
