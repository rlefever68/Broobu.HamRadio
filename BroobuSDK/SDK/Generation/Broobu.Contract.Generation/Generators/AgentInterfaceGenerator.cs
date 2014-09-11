// <copyright file="Generator1.cs" company="Microsoft">
//  Copyright © Microsoft. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using Iris.Contract.Generation.Domain;
using Iris.Contract.Generation.Templates;

namespace Iris.Contract.Generation.Generators
{

    public class AgentInterfaceGenerator : BaseGenerator
    {
        public AgentInterfaceGenerator()
            : base()
        {
        }

        public AgentInterfaceGenerator(String templateFilePath)
            : this()
        {
            WorkingDirectory = new DirectoryInfo(Path.Combine(Path.GetDirectoryName(templateFilePath), @"..\"));
        }

        protected override void RunCore()
        {
            if (LoadConfiguration())
            {
                List<Exception> exs = new List<Exception>();
                try
                {
                    foreach (ContractServiceDefinition Interface in _Configuration.ContractServiceInterfaces)
                    {
                        InterfaceTemplate template = new InterfaceTemplate();
                        template.Interface = (ContractAgentInterfaceDefinition)Interface;
                        template.Output.File = String.Format(@"{0}.cs", template.Interface.Name);
                        template.Render();
                    }
                }
                catch (Exception ex)
                {
                    exs.Add(ex);
                }
                if (exs.Count > 0)
                {
                    ErrorTemplate errortemplate = new ErrorTemplate();
                    ErrorTemplate.Exceptions = exs;
                    errortemplate.Output.File = "Error.log";
                    errortemplate.Render();
                    throw new Exception("See generated output for errors.");
                }
            }
        }

        //private void CreateInterface(String rootNamespace, String className, List<String> interfaceNames, List<MethodInfo> methods)
        //{

        //    try
        //    {
        //        AgentInterfaceTemplate aitemplate = new AgentInterfaceTemplate();
        //        aitemplate.ClassName = className;
        //        aitemplate.Interfaces = interfaceNames;
        //        aitemplate.Methods = methods;
        //        aitemplate.Namespace = String.Format("{0}.Interfaces", rootNamespace);
        //        aitemplate.RootNamespace = rootNamespace;
        //        aitemplate.RenderToFile(String.Format(@"{0}.cs", aitemplate.ClassName));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected override void Validate()
        {
            this.Warning("Generator properties have not been validated");
        }        
    }
}
