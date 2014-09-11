using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Contract.Generation.Common;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class ContractDefinition : NameItemDefinitionBase
    {
        public static String RelativeConfigurationFileLocation = @"GenerationConfiguration\ContractGenerationConfiguration.xml";

        private ContractServiceDefinition[] _ContractServiceInterfaces;
        private ContractServiceDefinition[] _UpdatedContractServiceInterfaces;
        private DomainObjectClassDefinition[] _DomainObjectClasses;
        private DomainObjectClassDefinition[] _UpdatedDomainObjectClasses;

        [XmlArrayItem("ContractServiceInterface", typeof(ContractServiceDefinition), IsNullable = false)]
        public virtual ContractServiceDefinition[] ContractServiceInterfaces
        {
            get
            {
                foreach (var contractServiceInterface in _ContractServiceInterfaces.Where(x => !_UpdatedContractServiceInterfaces.Select(y => y.Name).Contains(x.Name)))
                {
                    contractServiceInterface.Namespace = String.Format("Iris.{0}.Contract.Interfaces", Name);
                    contractServiceInterface.Modifier = Modifier.Public;
                    if (contractServiceInterface.Methods == null)
                        contractServiceInterface.Methods = new MethodDefinition[] { };

                    if (contractServiceInterface.Attributes == null)
                        contractServiceInterface.Attributes = new AttributeDefinition[] { };

                    _UpdatedContractServiceInterfaces = _UpdatedContractServiceInterfaces.Union(new ContractServiceDefinition[] { contractServiceInterface }).ToArray();
                }
                return _UpdatedContractServiceInterfaces;
            }
            set
            {
                if (ReferenceEquals(_ContractServiceInterfaces, value))
                    return;
                _ContractServiceInterfaces = value;
                _UpdatedContractServiceInterfaces = new ContractServiceDefinition[] { };
                OnPropertyChanged("ContractServiceInterfaces");
            }
        }

        [XmlArrayItem("DomainObjectClass", Type = typeof(DomainObjectClassDefinition), IsNullable = false)]
        public virtual DomainObjectClassDefinition[] DomainObjectClasses
        {
            get
            {
                foreach (var domainObjectClass in _DomainObjectClasses.Where(x => !_UpdatedDomainObjectClasses.Select(y => y.Name).Contains(x.Name)))
                {
                    domainObjectClass.Attributes = new AttributeDefinition[] { };
                    foreach (var property in domainObjectClass.Properties.Where(y => y.Type.IsEnum))
                    {
                        domainObjectClass.Attributes = domainObjectClass.Attributes.Union
                                                   (
                                                        new AttributeDefinition[]
                                                                                { 
                                                                                    #region Known type attributes
                                                                                    new AttributeDefinition
                                                                                    {
                                                                                        Name = "KnownType",
                                                                                        Type = new TypeDefinition
                                                                                        {
                                                                                            Namespace = "System.Runtime.Serialization",
                                                                                            Name = "KnownTypeAttribute",
                                                                                            IsStruct = false,
                                                                                            IsEnum = false,
                                                                                            Template = null
                                                                                        },
                                                                                        Value = String.Format("typeof({0})", property.Type.Name)
                                                                                    }
                                                                                    #endregion
                                                                                }
                                                   )
                                                   .ToArray();
                    }
                    if (domainObjectClass.BaseClass == null)
                        domainObjectClass.BaseClass = new TypeDefinition
                                      {
                                          Name = "DomainObject",
                                          Namespace = "Iris.Fx.Domain",
                                          IsEnum = false,
                                          IsStruct = false,
                                          Template = new TypeDefinition
                                          {
                                              Name = domainObjectClass.Name,
                                              Namespace = domainObjectClass.Namespace,
                                              IsEnum = false,
                                              IsStruct = false,
                                              Template = null
                                          }
                                      };
                    domainObjectClass.Events = new EventDefinition[] { };
                    domainObjectClass.Fields = new FieldDefinition[] { };
                    domainObjectClass.Interfaces = new TypeDefinition[] { };
                    domainObjectClass.IsPartial = true;
                    domainObjectClass.Methods = domainObjectClass.Methods.Union
                                         (
                                            new MethodDefinition[]
                                                                    {
                                                                        #region Validation methods
                                                                        new MethodDefinition
                                                                        {
                                                                            Name = "Validate",
                                                                            ReturnType = new TypeDefinition
                                                                            {
                                                                                Namespace = "System",
                                                                                Name = "string",
                                                                                IsEnum = false,
                                                                                IsStruct = false,
                                                                                Template = null,
                                                                            },
                                                                            Attributes = new AttributeDefinition[]{},
                                                                            Parameters = new ParameterDefinition[]
                                                                            {
                                                                                new ParameterDefinition
                                                                                {
                                                                                    Name="columnName",
                                                                                    Modifier= ParameterModifier.None,
                                                                                    Type= new TypeDefinition
                                                                                    {
                                                                                        Namespace="System",
                                                                                        Name="string",
                                                                                        IsEnum=false,
                                                                                        IsStruct=false,
                                                                                        Template=null,
                                                                                    }
                                                                                }
                                                                            },
                                                                            IsOverride = true,
                                                                            Modifier = Modifier.Protected,
                                                                            Body = String.Format("return DataErrorInfoValidator<{0}>.Validate(this, columnName);", domainObjectClass.Name)
                                                                        },
                                                                        new MethodDefinition
                                                                        {
                                                                            Name = "Validate",
                                                                            ReturnType = new TypeDefinition
                                                                            {
                                                                                Namespace = "System.Collections.Generic",
                                                                                Name = "ICollection",
                                                                                IsEnum = false,
                                                                                IsStruct = false,
                                                                                Template = new TypeDefinition
                                                                                {
                                                                                    Namespace = "System",
                                                                                    Name = "string",
                                                                                    IsEnum = false,
                                                                                    IsStruct = false,
                                                                                    Template = null
                                                                                }
                                                                            },
                                                                            Attributes = new AttributeDefinition[]{},
                                                                            Parameters = new ParameterDefinition[]{},
                                                                            IsOverride = true,
                                                                            Modifier = Modifier.Protected,
                                                                            Body = String.Format("return DataErrorInfoValidator<{0}>.Validate(this);", domainObjectClass.Name)
                                                                        },
                                                                        #endregion
                                                                        #region Partial methods
                                                                        new MethodDefinition
                                                                        {
                                                                            Name = "OnRaisePropertyChanged",                                                                            
                                                                            Parameters = new ParameterDefinition[]
                                                                            {
                                                                                new ParameterDefinition
                                                                                {
                                                                                    Name="propertyName",
                                                                                    Modifier= ParameterModifier.None,
                                                                                    Type= new TypeDefinition
                                                                                    {
                                                                                        Namespace="System",
                                                                                        Name="string",
                                                                                        IsEnum=false,
                                                                                        IsStruct=false,
                                                                                        Template=null,
                                                                                    }
                                                                                }
                                                                            },
                                                                            IsOverride = false,
                                                                            IsPartial = true,
                                                                            Modifier = Modifier.None                                                                            
                                                                        }
                                                                        #endregion
                                                                    }
                                         )
                                         .ToArray();
                    domainObjectClass.Modifier = Modifier.Public;
                    domainObjectClass.Namespace = String.Format("Iris.{0}.Contract.Domain", Name);
                    if (domainObjectClass.Properties != null)
                        foreach (var property in domainObjectClass.Properties)
                        {
                            if (!property.Attributes.Select(x => x.Name).Contains("DataMember"))
                            {
                                property.Attributes = new AttributeDefinition[]
                                                      {
                                                          new AttributeDefinition
                                                          {
                                                              Name = "DataMember",
                                                              Type = new TypeDefinition
                                                              {
                                                                  Namespace = "System.Runtime.Serialization",
                                                                  Name = "DataMemberAttribute",
                                                                  IsStruct = false,
                                                                  IsEnum = false,
                                                                  Template = null
                                                              }
                                                          }
                                                      }
                                                      .Union(property.Attributes)
                                                      .ToArray();
                            }
                            property.Modifier = Modifier.Public;
                            StringBuilder getBody = new StringBuilder();
                            StringBuilder setBody = new StringBuilder();
                            getBody.AppendLine(String.Format("return {0};", property.FieldName));
                            if (property.Type.IsValueType)
                            {
                                setBody.AppendLine(String.Format("if({0} != value)", property.FieldName));
                            }
                            else
                            {
                                setBody.AppendLine(String.Format("if(ReferenceEquals({0}, value) != true)", property.FieldName));
                            }
                            setBody.AppendLine("{");
                            setBody.Append("\t");
                            setBody.AppendLine(String.Format("{0} = value;", property.FieldName));
                            setBody.Append("\t");
                            setBody.AppendLine(String.Format(@"RaisePropertyChanged(""{0}"");", property.Name));
                            setBody.Append("\t");
                            setBody.AppendLine(String.Format(@"OnRaisePropertyChanged(""{0}"");", property.Name));
                            setBody.AppendLine("}");
                            property.GetBody = getBody.ToString();
                            property.SetBody = setBody.ToString();
                        }
                    _UpdatedDomainObjectClasses = _UpdatedDomainObjectClasses.Union(new DomainObjectClassDefinition[] { domainObjectClass }).ToArray();
                }

                return _UpdatedDomainObjectClasses;
            }
            set
            {
                if (ReferenceEquals(_DomainObjectClasses, value))
                    return;
                _DomainObjectClasses = value;
                _UpdatedDomainObjectClasses = new DomainObjectClassDefinition[] { };
                OnPropertyChanged("DomainClasses");
            }
        }

        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
                if (ContractServiceInterfaces != null)
                    list.AddRange(ContractServiceInterfaces.SelectMany(x => x.UsedNamespaces));
                if (DomainObjectClasses != null)
                    list.AddRange(DomainObjectClasses.SelectMany(x => x.UsedNamespaces));
                return list.Distinct().OrderBy(x => x).ToList();
            }
        }

        public ContractDefinition()
        {

        }

        public virtual String Serialize()
        {
            return Serialize(this);
        }

        public static String Serialize(object obj)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(ContractDefinition));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8Helper.UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static ContractDefinition Deserialize(String xml)
        {
                XmlSerializer xs = new XmlSerializer(typeof(ContractDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as ContractDefinition;
        }

        public static ContractDefinition LoadFromFile(String filePath)
        {
            FileInfo ConfigurationFile = new FileInfo(filePath);
            if (ConfigurationFile.Exists)
            {
                ContractDefinition result = null;
                Stream st = null;
                try
                {
                    st = ConfigurationFile.OpenRead();// File.OpenRead(ConfigFile);
                    StreamReader sr = new StreamReader(st);
                    var xmlstring = sr.ReadToEnd();
                    result = ContractDefinition.Deserialize(xmlstring);
                }
                finally
                {
                    if (result == null)
                        result = new ContractDefinition();
                    st.Close();
                }
                return result;
            }
            else
            {
                return new ContractDefinition();
            }
        }
    }

}
