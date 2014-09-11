// <copyright file="AgentClassTemplate.partial.cs" company="Microsoft">
//  Copyright © Microsoft. All Rights Reserved.
// </copyright>

using Iris.Contract.Generation.Common;
using Iris.Contract.Generation.Domain;

namespace Iris.Contract.Generation.Templates
{
    public partial class ClassTemplate
    {
        public IrisToStringHelper ToStringHelper = new IrisToStringHelper();

        public ClassDefinition Class { get; set; }

        public ClassTemplate()
            : base()
        { }

        public ClassTemplate(DomainObjectClassDefinition classObject)
        {
            Class = classObject;
        }

        protected override void Validate()
        {
                //this.Warning("Template properties have not been validated");
        }



    }
}
