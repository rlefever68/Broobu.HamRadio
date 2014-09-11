using System;
using System.Collections.Generic;
using System.IO;
using Iris.Contract.Generation.Domain;
using Iris.Contract.Generation.Templates;

namespace Iris.Contract.Generation.Generators
{
    class BusinessInterfaceGenerator : BaseGenerator
    {
        private BusinessInterfaceGenerator()
            : base()
        {
        }

        public BusinessInterfaceGenerator(String templateFilePath)
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
                    foreach (ContractServiceDefinition item in _Configuration.ContractServiceInterfaces)
                    {
                        item.IsPartial = true;
                        InterfaceTemplate template = new InterfaceTemplate();
                        template.Interface = (ContractBusinessInterfaceDefinition)item;
                        template.Output.File = String.Format(@"{0}.cs", item.Name);
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

        protected override void Validate()
        {
            this.Warning("Generator properties have not been validated");
        }
    }
}
