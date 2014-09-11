using System;
using System.Collections.Generic;
using System.IO;
using Iris.Contract.Generation.Templates;

namespace Iris.Contract.Generation.Generators
{
    public class DomainClassGenerator : BaseGenerator
    {
        private DomainClassGenerator()
            : base()
        {
        }

        public DomainClassGenerator(String templateFilePath)
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
                    foreach (var item in _Configuration.DomainObjectClasses)
                    {
                        ClassTemplate template = new ClassTemplate();
                        template.Class = item;
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
