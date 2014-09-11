// <copyright file="Template2.partial.cs" company="Microsoft">
//  Copyright © Microsoft. All Rights Reserved.
// </copyright>

using Iris.Contract.Generation.Common;
using Iris.Contract.Generation.Domain;

namespace Iris.Contract.Generation.Templates
{
    public partial class InterfaceTemplate 
    {
        public IrisToStringHelper ToStringHelper = new IrisToStringHelper();

        public InterfaceDefinition Interface { get; set; }

        public InterfaceTemplate()
            :base()
        { }

        public InterfaceTemplate(InterfaceDefinition interfaceObject)
        {
            Interface = interfaceObject;
        }

        protected override void Validate()
        {
                //this.Warning("Template properties have not been validated");
        }
    }
}
