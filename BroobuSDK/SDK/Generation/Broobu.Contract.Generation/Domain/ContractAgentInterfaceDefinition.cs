using System;
using System.Linq;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public partial class ContractAgentInterfaceDefinition : InterfaceDefinition
    {
        public static implicit operator ContractAgentInterfaceDefinition(ContractServiceDefinition serviceInterface)
        {
            if (serviceInterface == null)
                return null;

            var agentInterface = new ContractAgentInterfaceDefinition
            {
                Name = serviceInterface.Name.Insert(serviceInterface.Name.Length, "Agent"),
                Namespace = String.Format("{0}.Interfaces", serviceInterface.Namespace.Substring(0, serviceInterface.Namespace.LastIndexOf("."))),                
                Modifier=serviceInterface.Modifier,
                Interfaces = new TypeDefinition[] { new TypeDefinition { Name = serviceInterface.Name, Namespace = serviceInterface.Namespace } },
                IsPartial = true,                
                Events = serviceInterface.Methods.ToList()
                                                 .Select
                                                 (
                                                    x => new EventDefinition 
                                                         { 
                                                             Name = x.Name.Insert(x.Name.Length, "Completed"),                                                              
                                                             ActionTemplate = x.ReturnType != null && x.ReturnType.Name != "void" ? x.ReturnType : null, 
                                                             Modifier = Modifier.Public 
                                                         }
                                                 )
                                                 .ToArray(),
                Methods = serviceInterface.Methods.ToList().SelectMany(x => new MethodDefinition[]
                                                                            {   
                                                                                new MethodDefinition 
                                                                                {
                                                                                    Name=x.Name.Insert(x.Name.Length,"Async"),
                                                                                    IsAbstract=true, 
                                                                                    IsPartial=false, 
                                                                                    IsOverride=false, 
                                                                                    Modifier= Modifier.Public,                                                                                     
                                                                                    Parameters=x.Parameters.Union
                                                                                                           (
                                                                                                                new ParameterDefinition[] 
                                                                                                                { 
                                                                                                                    new ParameterDefinition
                                                                                                                    { 
                                                                                                                        Name="action", 
                                                                                                                        DefaultValue="null",
                                                                                                                        Type = new TypeDefinition
                                                                                                                               {
                                                                                                                                   Name="Action",
                                                                                                                                   Namespace="System", 
                                                                                                                                   IsEnum=false,
                                                                                                                                   IsStruct=false, 
                                                                                                                                   Template=x.ReturnType
                                                                                                                               }
                                                                                                                    }
                                                                                                                }
                                                                                                           )
                                                                                                           .ToArray() }
                                                                            }
                                                                      ).ToArray()
            };
            return agentInterface;
        }       
    }
}
