using System;
using Broobu.Hamdroid.Business;
using Broobu.Hamdroid.Contract.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Hamdroid.Contract.Test
{
    [TestClass]
    public class HamdroidTestFixture
    {
        [TestMethod]
        public void Try_GetCallSignInfo()
        {
            try
            {
                CallSignInfo res = HamdroidProvider
                    .Hamdroids
                    .GetCallSignInfo("ON8RL", 54.525, 5.256, "km");
                Console.WriteLine("Hello {0}", res.DisplayName);
                Assert.IsNotNull(res);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }


        [TestMethod]
        public void Try_RegiserDeviceLocation()
        {
            try
            {
                //var res = HamdroidProvider
                //    .Hamdroids
                //    .RegisterDeviceLocation("iPhone", 50.125123, 5.212335, 54.253, (float)125.265265, (float)12.548);
                DeviceLocation res = HamdroidPortal
                    .Agent
                    .RegisterDeviceLocation("iPhone", 50.125123, 5.212335, 54.253, (float) 125.265265, (float) 12.548);
                Console.WriteLine("Grid:{0}, Lat:{1}, Lon:{2}", res.DisplayGrid, res.DisplayLatitude,
                    res.DisplayLongitude);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);

                throw;
            }
        }
    }
}