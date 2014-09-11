using System;
using System.Collections.Generic;
using System.IO;
using Iris.Contract.Generation.Domain;
using Iris.Contract.Generation.Templates;

namespace Iris.Contract.Generation.Generators
{
    public class ServiceHostGenerator : BaseGenerator
    {
        public ServiceHostGenerator()
            : base()
        {
        }

        public ServiceHostGenerator(String templateFilePath, String domainName)
            : this()
        {
            WorkingDirectory = new DirectoryInfo(Path.Combine(Path.GetDirectoryName(templateFilePath), String.Format(@"..\..\Contract\Iris.{0}.Contract\", domainName)));
            //WorkingDirectory = new DirectoryInfo(Path.Combine(Path.GetDirectoryName(templateFilePath), @"..\"));
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
                        ServiceHostTemplate template = new ServiceHostTemplate();
                        template.ServiceHostDefinition = (ContractServiceHostDefinition)Interface;
                        template.Output.File = String.Format(@"{0}.svc", template.ServiceHostDefinition.Name);
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

        //private void CreateAgent(String rootNamespace, String className, String baseClassName, List<String> interfaceNames, List<MethodInfo> methods)
        //{
        //    try
        //    {
        //        AgentClassTemplate actemplate = new AgentClassTemplate();
        //        actemplate.ClassName = className;
        //        actemplate.BaseClass = baseClassName;
        //        actemplate.Interfaces = interfaceNames;
        //        actemplate.Methods = methods;
        //        actemplate.Namespace = String.Format("{0}.Agent", rootNamespace);
        //        actemplate.RootNamespace = rootNamespace;
        //        actemplate.AdditionalUsings.Add("Iris.Framework");
        //        actemplate.AdditionalUsings.Add("Iris.Fx.Networking.Wcf");
        //        actemplate.RenderToFile(String.Format(@"{0}.cs", actemplate.ClassName));
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
