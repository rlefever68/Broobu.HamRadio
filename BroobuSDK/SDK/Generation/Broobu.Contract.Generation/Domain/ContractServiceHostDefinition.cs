using System;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public partial class ContractServiceHostDefinition : ServiceHostDefinition
    {
        public static implicit operator ContractServiceHostDefinition(ContractServiceDefinition serviceInterface)
        {
            if (serviceInterface == null)
                return null;

            var namespaceWithoutLast = serviceInterface.Namespace.Substring(0, serviceInterface.Namespace.LastIndexOf("."));
            var agentClass = new ContractServiceHostDefinition
            {
                Name = serviceInterface.Name.Substring(1),
                Namespace = String.Format("{0}.Service", namespaceWithoutLast.Substring(0, namespaceWithoutLast.LastIndexOf("."))),
            };
            return agentClass;
        }
    }

}
