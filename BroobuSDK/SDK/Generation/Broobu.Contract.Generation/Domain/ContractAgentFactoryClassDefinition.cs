using System;
using System.Linq;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public partial class ContractAgentFactoryClassDefinition : ClassDefinition
    {
        public static ContractAgentFactoryClassDefinition GetAgentFactory(ContractServiceDefinition[] serviceInterfaces, String businessName)
        {
            if (serviceInterfaces == null)
                return null;

            var agentFactoryClass = new ContractAgentFactoryClassDefinition
            {

                Name = String.Format("{0}AgentFactory", businessName.Contains('.') ? businessName.Substring(businessName.LastIndexOf('.') + 1) : businessName),
                Namespace = String.Format("Iris.{0}.Contract.Agent", businessName),
                Modifier = Modifier.Public,
                IsPartial = true,
                Methods = serviceInterfaces.ToList()
                                           .SelectMany
                                           (
                                                x => new MethodDefinition[]
                                                {
                                                    new MethodDefinition 
                                                    {
                                                        Name=String.Format("Create{0}Agent",x.Name.Substring(1)),
                                                        IsAbstract=false, 
                                                        IsPartial=false, 
                                                        IsStatic=true,
                                                        IsOverride=false, 
                                                        ReturnType=new TypeDefinition
                                                        {
                                                            Name=String.Format("{0}Agent",x.Name),
                                                            Namespace=x.Namespace,
                                                            IsEnum=false,
                                                            IsStruct=false
                                                        }, 
                                                        Modifier= Modifier.Public,                                                        
                                                        Body=String.Format("return new {0}Agent();",x.Name.Substring(1))
                                                    }
                                                }
                                          )
                                          .ToArray()
            };
            return agentFactoryClass;
        }
    }
}
