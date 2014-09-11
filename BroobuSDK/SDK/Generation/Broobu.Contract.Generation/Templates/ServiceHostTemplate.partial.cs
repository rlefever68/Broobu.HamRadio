// <copyright file="ServiceHostTemplate.partial.cs" company="Microsoft">
//  Copyright © Microsoft. All Rights Reserved.
// </copyright>

using Iris.Contract.Generation.Common;
using Iris.Contract.Generation.Domain;

namespace Iris.Contract.Generation.Templates
{
    public partial class ServiceHostTemplate
    {

        public IrisToStringHelper ToStringHelper = new IrisToStringHelper();

        public ServiceHostDefinition ServiceHostDefinition { get; set; }

        protected override void Validate()
        {
        }
    }
}
