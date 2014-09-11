using System;
using Broobu.LATI.Business;
using Broobu.LATI.Contract.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.LATI.Contract.Test
{
    [TestClass]
    public class LatiTestFixture
    {
        [TestMethod]
        public void Try_RegisterDomain()
        {
            try
            {
                LatiProvider
                    .Cultures
                    .RegisterDomain();

            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);               
            }
        }



        [TestMethod]
        public void Try_RegisterLocationLog()
        {
            try
            {
                LocationLog log = new LocationLog() {PoIId = "My bedroom", Accuracy = (float)0.0, Bearing = (float)123.01532, Latitude = 56.25153, Longitude = 6.235, Altitude = 51.212, Speed = (float)2.3};
                //log = LatiProvider
                //    .Latis
                //    .RegisterLocation(log);
                log = LatiPortal
                    .Latis
                    .RegisterLocation(log);
                Console.WriteLine("Log: {0} - Lon:{1}", log.PoIId, log.Longitude);

            }
            catch (Exception exception)
            {
                Assert.Fail(exception.Message);               
            }
        }

    }
}
