using System;
using System.Linq;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    partial class ContractBusinessInterfaceDefinition : InterfaceDefinition
    {
        public static implicit operator ContractBusinessInterfaceDefinition(ContractServiceDefinition serviceInterface)
        {
            if (serviceInterface == null)
                return null;

            var namespaceWithoutLast = serviceInterface.Namespace.Substring(0, serviceInterface.Namespace.LastIndexOf("."));
            var baseNamespace = namespaceWithoutLast.Substring(0, namespaceWithoutLast.LastIndexOf("."));
            var agentInterface = new ContractBusinessInterfaceDefinition
            {
                Name = serviceInterface.Name.Insert(serviceInterface.Name.Length, "Provider"),
                Namespace = String.Format("{0}.Business.Interfaces", baseNamespace),
                Modifier = Modifier.Public,
                Interfaces = new TypeDefinition[] { new TypeDefinition { Name = "IProvider", Namespace = serviceInterface.Namespace } },
                IsPartial = false,
                Methods = serviceInterface.Methods
                                          .ToList()
                                          .SelectMany
                                          (
                                            x => new MethodDefinition[]
                                                 {

                                                     new MethodDefinition 
                                                     {
                                                         Name=x.Name,
                                                         IsAbstract=false, 
                                                         IsPartial=false, 
                                                         IsOverride=false, 
                                                         ReturnType=x.ReturnType, 
                                                         Modifier= Modifier.None, 
                                                         Parameters=x.Parameters,
                                                         Attributes = x.Attributes,
                                                     },
                                                 }
                                          )
                                          .ToArray(),
            };
            return agentInterface;
        }
    }

}
