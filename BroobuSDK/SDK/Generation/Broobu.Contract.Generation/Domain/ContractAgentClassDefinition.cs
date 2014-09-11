using System;
using System.Linq;
using System.Text;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public partial class ContractAgentClassDefinition : ClassDefinition
    {
        public static implicit operator ContractAgentClassDefinition(ContractServiceDefinition serviceInterface)
        {
            if (serviceInterface == null)
                return null;

            var agentClass = new ContractAgentClassDefinition
                                 {
                                     Name =
                                         serviceInterface.Name.Insert(serviceInterface.Name.Length, "Agent").Substring(1),
                                     Namespace =
                                         String.Format("{0}.Agent",
                                                       serviceInterface.Namespace.Substring(0,
                                                                                            serviceInterface.Namespace.
                                                                                                LastIndexOf("."))),
                                     Modifier = Modifier.None,
                                     Interfaces = new TypeDefinition[]
                                                      {
                                                          new TypeDefinition
                                                              {
                                                                  Name =
                                                                      serviceInterface.Name.Insert(
                                                                          serviceInterface.Name.Length, "Agent"),
                                                                  Namespace = serviceInterface.Namespace
                                                              }
                                                      },
                                     IsPartial = true,
                                     BaseClass = new TypeDefinition
                                                     {
                                                         Name = "DiscoProxy",
                                                         Namespace = "Iris.Fx.Networking.Wcf",
                                                         IsEnum = false,
                                                         IsStruct = false,
                                                         Template = new TypeDefinition
                                                                        {
                                                                            Name = serviceInterface.Name,
                                                                            Namespace = serviceInterface.Namespace
                                                                        }
                                                     },
                                     Constructors = new ConstructorDefinition[]{ },
                                     Fields = new FieldDefinition[]
                                                  {
                                                      new FieldDefinition
                                                          {
                                                              Modifier = Domain.Modifier.Private,
                                                              Name = "Logger",                                                              
                                                              IsReadOnly = true,
                                                              IsStatic = true,
                                                              InitialValueString = "LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)",
                                                              Type = new TypeDefinition()
                                                                         {
                                                                             IsEnum = false,
                                                                             IsStruct = false,
                                                                             Name = "ILog",
                                                                             Namespace = "log4net"
                                                                         }
                                    }
                             },
                                     Events = serviceInterface.Methods
                                                              .ToList()
                                                              .Select
                                                              (
                                                                 x => new EventDefinition
                                                                      {
                                                                          Name = x.Name.Insert(x.Name.Length, "Completed"),
                                                                          ActionTemplate = (x.ReturnType != null && x.ReturnType.Name != "void") ? x.ReturnType : null,
                                                                          Modifier = Modifier.Public
                                                                      }
                                                              )
                                                              .ToArray(),
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
                                                         Modifier= Modifier.Public, 
                                                         Parameters=x.Parameters,
                                                         Body=GetSynchronousBody(serviceInterface.Name,x)
                                                     },
                                                     new MethodDefinition 
                                                     {
                                                         Name=x.Name.Insert(x.Name.Length,"Async"),
                                                         IsAbstract=false, 
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
                                                                                            Type = new TypeDefinition
                                                                                                   { 
                                                                                                       Name="Action",
                                                                                                       Namespace="System", 
                                                                                                       IsEnum=false,
                                                                                                       IsStruct=false, 
                                                                                                       Template=x.ReturnType
                                                                                                   },
                                                                                            DefaultValue="null"
                                                                                        }
                                                                                    }
                                                                                )
                                                                                .ToArray(),
                                                         Body=GetAsynchronousBody(serviceInterface.Name,x) 
                                                     }
                                                 }
                                                               )
                                                               .Union(new MethodDefinition[] 
                                          { 
                                              new MethodDefinition
                                                     {
                                                         Name = "GetContractNamespace",
                                                         Modifier= Domain.Modifier.Protected,
                                                         IsAbstract = false,
                                                         IsPartial = false,
                                                         IsOverride = true,
                                                         ReturnType = new TypeDefinition() {Name="string", Namespace="System"},
                                                         Body = GetGetContractNamespaceBody(serviceInterface.ServiceContractNamespace)
                                                     }
                                          })
                                                               .ToArray()
                                 };
            return agentClass;
        }

        private static string GetGetContractNamespaceBody(string contractNamespace)
        {
            if (String.IsNullOrEmpty(contractNamespace))
                return "return Iris.Fx.Domain.ServiceConst.Namespace;";
            return String.Format(@"return ""{0}"";", contractNamespace);
        }

        private static string GetAsynchronousBody(String serviceInterfaceName, MethodDefinition x)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())");
            sb.AppendLine("{");
            if (x.ReturnType != null && x.ReturnType.Name != "void")
            {
                sb.Append("\t");
                sb.AppendLine(String.Format("var res = ({0})null;", x.ReturnType.FullName));
            }
            sb.Append("\t");
            sb.AppendLine("wrk.DoWork += (s, e) =>");
            sb.Append("\t");
            sb.AppendLine("{");
            sb.Append("\t");
            sb.Append("\t");
            if (x.ReturnType != null && x.ReturnType.Name != "void")
                sb.Append("res = ");

            sb.AppendFormat("{0}(", x.Name);
            foreach (var item in x.Parameters)
            {
                if (item != x.Parameters.First())
                    sb.Append(", ");
                sb.Append(item.Name);
            }
            sb.AppendLine(");");
            sb.Append("\t");
            sb.AppendLine("};");
            sb.Append("\t");
            sb.AppendLine("wrk.RunWorkerCompleted += (s, e) =>");
            sb.Append("\t");
            sb.AppendLine("{");
            sb.Append("\t");
            sb.Append("\t");
            sb.AppendLine("if (action != null)");
            sb.Append("\t");
            sb.Append("\t");
            sb.Append("\t");
            sb.Append("action(");
            if (x.ReturnType != null && x.ReturnType.Name != "void")
                sb.Append("res");
            sb.AppendLine(");");
            sb.Append("\t");
            sb.Append("\t");
            sb.AppendLine(String.Format("else if ({0}Completed != null)", x.Name));
            sb.Append("\t");
            sb.Append("\t");
            sb.Append("\t");
            sb.AppendFormat("{0}Completed(", x.Name);
            if (x.ReturnType != null && x.ReturnType.Name != "void")
                sb.Append("res");
            sb.AppendLine(");");
            sb.Append("\t");
            sb.Append("\t");
            sb.AppendLine("wrk.Dispose();");
            sb.Append("\t");
            sb.AppendLine("};");
            sb.Append("\t");
            sb.AppendLine("wrk.RunWorkerAsync();");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static string GetSynchronousBody(String serviceInterfaceName, MethodDefinition x)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();");
            sb.AppendLine("if (Logger.IsDebugEnabled)");
            sb.AppendLine("{");
            sb.Append("\t");
            sb.AppendFormat(@"Logger.Debug(""Method {0}.{1} started"");", serviceInterfaceName, x.Name);
            sb.AppendLine();
            sb.Append("\t");
            sb.AppendLine("timer.Start();");
            sb.AppendLine("}");
            sb.AppendFormat("{0} clt = null;", serviceInterfaceName);
            sb.AppendLine();
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.Append("\t");
            sb.AppendLine("if (Logger.IsDebugEnabled)");
            sb.Append("\t");
            sb.AppendLine("{");
            sb.Append("\t\t");
            sb.AppendLine(@"Logger.DebugFormat(""Creating client ({0})"", timer.Elapsed);");
            sb.Append("\t");
            sb.AppendLine("}");
            sb.Append("\t");
            sb.AppendLine("clt = CreateClient();");
            sb.Append("\t");
            sb.AppendLine("if (Logger.IsDebugEnabled)");
            sb.Append("\t");
            sb.AppendLine("{");
            sb.Append("\t\t");
            sb.AppendFormat(@"Logger.DebugFormat(""Calling client.{0} ({{0}})"", timer.Elapsed);", x.Name);
            sb.AppendLine();
            sb.Append("\t");
            sb.AppendLine("}");
            sb.Append("\t");
            if (x.ReturnType != null && x.ReturnType.Name != "void")
                sb.Append("return ");
            sb.AppendFormat("clt.{0}(", x.Name);
            foreach (var item in x.Parameters)
            {
                if (item != x.Parameters.First())
                    sb.Append(", ");
                sb.Append(item.Name);
            }
            sb.AppendLine(");");
            sb.AppendLine("}");
            sb.AppendLine("finally");
            sb.AppendLine("{");
            sb.Append("\t");
            sb.AppendLine("if (Logger.IsDebugEnabled)");
            sb.Append("\t");
            sb.AppendLine("{");
            sb.Append("\t\t");
            sb.AppendLine(@"Logger.DebugFormat(""Closing client ({0})"", timer.Elapsed);");
            sb.Append("\t");
            sb.AppendLine("}");
            sb.Append("\t");
            sb.AppendLine("CloseClient(clt);");
            sb.Append("\t");
            sb.AppendLine("if (Logger.IsDebugEnabled)");
            sb.Append("\t");
            sb.AppendLine("{");
            sb.Append("\t\t");
            sb.AppendFormat(@"Logger.DebugFormat(""Method {0}.{1} finished ({{0}})"", timer.Elapsed);", serviceInterfaceName, x.Name);
            sb.AppendLine();
            sb.Append("\t");
            sb.AppendLine("}");
            sb.Append("}");
            return sb.ToString();
        }
    }
}
