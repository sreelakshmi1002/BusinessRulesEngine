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
    public class BookPaymentTest : ProcessOrderTestFixture
    {
        IProcessOrder OrderProcess;

        [Test]
        public void When_I_Pass_Valid_BookOrder_it_should_process()
        {
            //arrange
            var book = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.BOOK).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.BOOK);
            double royaltyAmount = book.Price * book.Quantity * book.Commission;
            string message = "Royalty payment slip created with Amount -" + royaltyAmount;

            //act
            var result = OrderProcess.ProcessPayment(book);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(message, result.Message);
            
        }

        [Test]
        public void ProcessOrder_BookName_Empty_Test()
        {

            //arrange
            var book = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.BOOK).FirstOrDefault();
            book.Name = string.Empty;
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.BOOK);
            double royaltyAmount = book.Price * book.Quantity * book.Commission;

            //assert
            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcess.ProcessPayment(book));
            Assert.That(ex.Message, Is.EqualTo("Book Name is missing"));

        }
    }
}
