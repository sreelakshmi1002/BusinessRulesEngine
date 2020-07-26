using BusinessRuleEngine.Common;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Models;
using BusinessRulesEngine.UI;
using System;

namespace BusinessRulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputValue;
            Console.WriteLine("Order Process System \n");
            Console.WriteLine("******************************** \n");
            Console.WriteLine("1: Process Physical Product \n" +
                              "2: Process Book Order \n" +
                              "3: New Activation for Member\n" +
                              "4: Process Video \n" +
                              "5: Process Physical or Book\n" +
                              "6: Upgrade Member\n");

            Console.WriteLine("********************************");
            var getUserInput = Console.ReadLine();

            if (Int32.TryParse(getUserInput, out inputValue))
            {
                ProcessPayment(inputValue);
            }
            else
            {
                Console.WriteLine("Please enter a valid option Number!");
            }
            Console.Read();
        }

        private static void ProcessPayment(int options)
        {
            int memberShipType = 0;
            var paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), options.ToString());
            if (options == 3 || options == 6)
            {
                paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), "3".ToString());
                memberShipType = options == 3 ? 1 : 2;
                var result = ProcessOrders.GetPaymentMethod(paymentType);
                var sampleInput = SampleInput.GetSampleDataMember(memberShipType);

                if (result != null)
                {
                    var data = result.ProcessPayment(sampleInput);

                    Console.WriteLine($"Order of {paymentType.ToString()} and  {data.Message}\n");
                }
                else
                {
                    Console.WriteLine("Invalid operation");
                }

            }
            else
            {
                IProcessOrder processor = ProcessOrders.GetPaymentMethod(paymentType);
                var data = SampleInput.GetSampleDataForOrder(paymentType);
                if (processor != null)
                {
                    var result = processor.ProcessPayment(data);

                    Console.WriteLine($"Order of {paymentType.ToString()} and  {result.Message}\n");
                }
                else
                {
                    Console.WriteLine("Invalid operation");
                }
            }


        }
    }
}
