using System;
using System.Linq;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public partial class ContractServiceInterfaceDefinition : InterfaceDefinition
    {
        public static implicit operator ContractServiceInterfaceDefinition(ContractServiceDefinition serviceInterface)
        {
            if (serviceInterface == null)
                return null;

            var agentInterface = new ContractServiceInterfaceDefinition
            {
                Name = serviceInterface.Name,
                Namespace = serviceInterface.Namespace,
                Modifier = serviceInterface.Modifier,
                Interfaces = serviceInterface.Interfaces,
                IsPartial = serviceInterface.IsPartial,
                Events = serviceInterface.Events,
                Methods = serviceInterface.Methods,
                Attributes = serviceInterface.Attributes,
            };

            foreach (var method in agentInterface.Methods)
            {
                method.IsAbstract = true;
                if (!method.Attributes.ToList().Any(z => z.Name == "OperationContract"))
                    method.Attributes = method.Attributes
                        .Union(method.InterfaceAttributes)
                        .Union
                                                         (
                                                            new AttributeDefinition[]
                                                                    {                                                                    
                                                                        new AttributeDefinition 
                                                                        { 
                                                                            Name = "OperationContract", 
                                                                            Type = new TypeDefinition 
                                                                                   { 
                                                                                       Name = "OperationContractAttribute", 
                                                                                       Namespace = "System.ServiceModel", 
                                                                                       IsStruct = false, 
                                                                                       IsEnum = false, 
                                                                                       Template = null 
                                                                                   } 
                                                                        }
                                                                    }
                                                         )
                                                         .ToArray();
                method.IsOverride = false;
                method.IsPartial = false;
                method.Modifier = Modifier.None;
            }

            agentInterface.Attributes = agentInterface.Attributes.Union
                (
                    new AttributeDefinition[]
                        {
                            new AttributeDefinition
                                {
                                    Name = "ServiceContract",
                                    Type = new TypeDefinition
                                               {
                                                   IsEnum = false,
                                                   IsStruct = false,
                                                   Name = "ServiceContractAttribute",
                                                   Namespace = "System.ServiceModel"
                                               },
                                    Value = GetServiceNamespace(serviceInterface.ServiceContractNamespace)
                                }
                        }
                )
                .ToArray();

            return agentInterface;
        }

        private static string GetServiceNamespace(string contractServiceInterface)
        {
            if (String.IsNullOrWhiteSpace(contractServiceInterface))
                return "Namespace = Iris.Fx.Domain.ServiceConst.Namespace";
            return String.Format(@"Namespace = ""{0}""", contractServiceInterface);
        }

    }
}
