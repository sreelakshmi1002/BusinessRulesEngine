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
    public class VideoPaymentTest : ProcessOrderTestFixture
    {
        IProcessOrder OrderProcess;

        [Test]
        public void When_I_Pass_Valid_VideoOrder_it_should_processandAddFreeOrder()
        {
            //arrange
            var video = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.VIDEO).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.VIDEO);
            video.Description = "learning to ski";
            video.PackagingDate = DateTime.Today;

            //act
            var result = OrderProcess.ProcessPayment(video);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Added First Aid video to the packing slip.", result.Message);


        }

        [Test]
        public void When_I_Pass_Valid_VideoOrder_it_should_process()
        {
            //arrange
            var video = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.VIDEO).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.VIDEO);
            video.Description = "TestVideos";
            video.PackagingDate = DateTime.Today;

            //act
            var result = OrderProcess.ProcessPayment(video);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Generated Packing slip", result.Message);


        }

        [Test]
        public void ProcessOrder_BookName_Empty_Test()
        {

            //arrange
            var video = GetProductInfo().Where(x => x.ProductType == Models.ProductTypes.VIDEO).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(Models.PaymentType.VIDEO);
            video.Description = string.Empty;

            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcess.ProcessPayment(video));
            Assert.That(ex.Message, Is.EqualTo("Video Descrption is missing"));

        }
    }
}
