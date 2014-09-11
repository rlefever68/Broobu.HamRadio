using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Iris.Contract.Generation.Domain;

namespace ClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamWriter y = null;
            try
            {
                var x = ContractDefinition.LoadFromFile(@"XMLFile1.xml");

                string subfolder = "Contract\\Interfaces\\";
                if (!Directory.Exists(subfolder))
                    Directory.CreateDirectory(subfolder);

                foreach (var item in x.ContractServiceInterfaces)
                {
                    File.WriteAllText(subfolder + item.Name + ".cs", item.GenerateCode());
                }

                foreach (var item in x.ContractServiceInterfaces)
                {
                    File.WriteAllText(subfolder + item.Name + "Agent.cs", ((ContractAgentInterfaceDefinition)item).GenerateCode());
                }

                subfolder = "Contract\\Agent\\";
                if (!Directory.Exists(subfolder))
                    Directory.CreateDirectory(subfolder);

                foreach (var item in x.ContractServiceInterfaces)
                {
                    File.WriteAllText(subfolder + item.Name.Substring(1) + "Agent.cs", ((ContractAgentClassDefinition)item).GenerateCode());
                }

                File.WriteAllText(subfolder + x.Name + "ProviderFactory.cs", ContractAgentFactoryClassDefinition.GetAgentFactory(x.ContractServiceInterfaces, x.Name).GenerateCode());

                subfolder = "Service\\";
                if (!Directory.Exists(subfolder))
                    Directory.CreateDirectory(subfolder);

                foreach (var item in x.ContractServiceInterfaces)
                {
                    File.WriteAllText(subfolder + item.Name.Substring(1) + ".cs", ((ContractServiceClassDefinition)item).GenerateCode());
                }

                foreach (var item in x.ContractServiceInterfaces)
                {
                    File.WriteAllText(subfolder + item.Name.Substring(1) + ".svc", ((ContractServiceHostDefinition)item).GenerateCode());
                }

                subfolder = "Contract\\Domain\\";
                if (!Directory.Exists(subfolder))
                    Directory.CreateDirectory(subfolder);

                foreach (var item in x.DomainObjectClasses)
                {
                    File.WriteAllText(subfolder + item.Name + ".cs", ((DomainObjectClassDefinition)item).GenerateCode());
                }

            }
            finally
            {
                //y.Close();
            }



        }
    }
}
