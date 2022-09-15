using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using CalculatorService.ServiceInterface;
using CalculatorService.ServiceModel;
using System;

namespace CalculatorService.Tests
{
    public class UnitTest
    {
        private readonly ServiceStackHost appHost;

        public UnitTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<CalculatorServices>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();


        [Test]
        public void Simple_Operations()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = service.Any(new Calculate
            {
                MyMaths = new Mymaths
                {
                    MyOperation = new Myoperation
                    {
                        ID = "Plus",
                        Value = new string[] { "2", "3" }
                    }
                }
            });

            Assert.That(response.Result, Is.EqualTo(5));
        }

        [Test]
        public void Complex_Operations()
        {
            var service = appHost.Container.Resolve<CalculatorServices>();

            var response = service.Any(new Calculate
            {
                MyMaths = new Mymaths
                {
                    MyOperation = new Myoperation
                    {
                        ID = "Plus",
                        Value = new string[] { "2", "3" },
                        MyOperation = new Myoperation
                        {
                            ID = "Multiplication",
                            Value = new string[] { "4", "5" }
                        }
                    }
                }
            });

            Assert.That(response.Result, Is.EqualTo(25));
        }
    }
}
