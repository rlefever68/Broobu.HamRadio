using System;
using Broobu.CloudMon.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.CloudMon.Rest.Contract.Test
{
    [TestClass]
    public class CloudMonTestFixture
    {
        [TestMethod]
        public void Try_GetAllEndpoints()
        {
            var res = CloudMonPortal
                .Agent
                .GetEndpoints();
            Console.WriteLine("Layer\t\t\tContract");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            foreach (var discoInfo in res)
            {
                Console.WriteLine("{0}\t\t\t{1}",  discoInfo.Layer,discoInfo.Contract);
            }
        }




    }

}
