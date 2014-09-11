using System;
using System.Linq;
using System.Text;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public partial class ContractServiceClassDefinition : ClassDefinition
    {
        public static implicit operator ContractServiceClassDefinition(ContractServiceDefinition serviceInterface)
        {
            if (serviceInterface == null)
                return null;

            var namespaceWithoutLast = serviceInterface.Namespace.Substring(0, serviceInterface.Namespace.LastIndexOf("."));
            var baseNamespace = namespaceWithoutLast.Substring(0, namespaceWithoutLast.LastIndexOf("."));
            var agentClass = new ContractServiceClassDefinition
                                 {
                                     Name =
                                         serviceInterface.Name.Insert(serviceInterface.Name.Length, "Service").Substring
                                         (1),
                                     Namespace = String.Format("{0}.Service", baseNamespace),
                                     Modifier = Modifier.Public,
                                     Interfaces = new TypeDefinition[]
                                                      {
                                                          new TypeDefinition
                                                              {
                                                                  Name = serviceInterface.Name,
                                                                  Namespace = serviceInterface.Namespace
                                                              }
                                                      },
                                     IsPartial = true,
                                     BaseClass = new TypeDefinition
                                                     {
                                                         Name = "BusinessServiceBase",
                                                         Namespace = "Iris.Fx.Networking.Wcf",
                                                         IsEnum = false,
                                                         IsStruct = false,
                                                     },
                                     Methods = serviceInterface.Methods
                                         .ToList()
                                         .SelectMany
                                         (
                                             x => new MethodDefinition[]
                                                      {

                                                          new MethodDefinition
                                                              {
                                                                  Name = x.Name,
                                                                  IsAbstract = false,
                                                                  IsPartial = false,
                                                                  IsOverride = false,
                                                                  ReturnType = x.ReturnType,
                                                                  Modifier = Modifier.Public,
                                                                  Parameters = x.Parameters,
                                                                  Body =
                                                                      GetSynchronousBody(
                                                                          serviceInterface.Name.Substring(1),
                                                                          baseNamespace, x),
                                                                  Attributes =
                                                                      x.Attributes.Union(x.ServiceAttributes).ToArray(),
                                                              },
                                                      }
                                         )
                                         .Union(new[]
                                                    {
                                                        new MethodDefinition
                                                            {
                                                                Name = "RegisterRequiredDomainObjects",
                                                                Modifier = Modifier.Protected,
                                                                IsOverride = true,
                                                                Body = "OnRegisterRequiredDomainObjects();",
                                                            },
                                                        new MethodDefinition
                                                            {
                                                                Name = "OnRegisterRequiredDomainObjects",
                                                                Modifier = Modifier.None,
                                                            IsPartial = true,
                                                        }
                                                    }
                                               )
                                          .ToArray(),
                Attributes = new AttributeDefinition[]
                                  {
                                      new AttributeDefinition
                                          {
                                              Name = "ServiceBehavior",
                                              Type =  new TypeDefinition
                                                          {
                                                              IsEnum = false,
                                                              IsStruct = false,
                                                              Name = "ServiceBehavior",
                                                              Namespace = "System.ServiceModel",
                                                          },
                                              Value = "IncludeExceptionDetailInFaults = true",
                                          }
                                  }
            };
            return agentClass;
        }

        private static string GetSynchronousBody(String serviceInterfaceName, string baseNamespace, MethodDefinition x)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"return {0}.Business.Factory.{1}ProviderFactory
                .CreateProvider(DataMode)
                .{2}", baseNamespace, serviceInterfaceName, x.Name);
            sb.Append("(");

            if (x.Parameters.Length > 0)
            {
                for (int i = 0; i < x.Parameters.Length - 1; i++)
                {
                    sb.Append(x.Parameters[i].Name);
                    sb.Append(", ");
                }
                sb.Append(x.Parameters[x.Parameters.Length - 1].Name);
            }
            sb.Append(");");
            return sb.ToString();
        }
    }
}
