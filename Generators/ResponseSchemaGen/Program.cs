using Destiny2ApiGenerator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseSchemaGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("openapi.json");
            dynamic BaseJson = JsonConvert.DeserializeObject<dynamic>(text);
            List<RawSchema> RawSchema = new List<RawSchema>();
            List<NewEnum> Enums = new List<NewEnum>();

            foreach (JProperty Definition in BaseJson.components.schemas)
            {
            #region Check
                JProperty namecheck = (JProperty)Definition.First.First;
                if (namecheck.Name == "enum") {


                    NewEnum _newenum = new NewEnum();
                    _newenum.EnumValues = new Dictionary<int, string>();
                    foreach (var EnumValue in Definition.First.Last)
                    {
                        foreach (var val in EnumValue)
                        {
                            _newenum.Name = (string)Definition.Name;
                            _newenum.GenerateNamespace();
                            int num = (int)val.SelectToken("numericValue");
                            string Id = (string)val.SelectToken("identifier");
                            _newenum.EnumValues.Add(num, Id);
                        }
                    }
                    Enums.Add(_newenum);


                }
                if (namecheck.Name == "properties")
#endregion
                {
                    RawSchema _schema = new RawSchema();
                    _schema.RawName = Definition.Name;
                    _schema.GenerateNamespace();

            #region Description
                    if (namecheck.Next != null)
                    {
                        JProperty desc = (JProperty)namecheck.Next;
                        if (desc.Name == "description")
                            _schema.Description = desc.Value.ToString();
                    }
                    #endregion

                    foreach (JProperty Property in namecheck.First)
                    {
                        SchemaProperty _prop = new SchemaProperty();
                        foreach (JProperty PropertyInfo in Property.First)
                        {
                           switch(PropertyInfo.Name)
                            {
                                case "type":
                                    _prop.Type = PropertyInfo.Value.ToString();
                                    _prop.Name = Property.Name;
                                    break;
                                case "format":
                                    _prop.Format = PropertyInfo.Value.ToString();
                                    break;
                                case "nullable":
                                    _prop.Nullable = Convert.ToBoolean(PropertyInfo.Value);
                                    break;
                                case "$ref":
                                    _prop.Ref = PropertyInfo.Value.ToString();
                                    _prop.Name = Property.Name;
                                    break;
                                case "items":
                                    _prop.Items = new List<object>();
                                    _prop.Items.Add(PropertyInfo.Value);
                                    break;
                                case "description":
                                    _prop.Description = PropertyInfo.Value.ToString();
                                    break;
                                case "allOf":
                                    _prop.AllOf = new List<object>();
                                    _prop.AllOf.Add(PropertyInfo.Value);
                                    break;
                                case "additionalProperties":
                                    _prop.AdditionalProperties = new List<object>();
                                    _prop.AdditionalProperties.Add(PropertyInfo.Value);
                                    break;
                                case "x-dictionary-key":
                                    _prop.XDictionaryKey = new List<object>();
                                    _prop.XDictionaryKey.Add(PropertyInfo.Value);
                                    break;
                                case "x-mapped-definition":
                                    _prop.XMappedDefinition = new List<object>();
                                    _prop.XMappedDefinition.Add(PropertyInfo.Value);
                                    break;
                                case "x-destiny-component-type-dependency":
                                    _prop.xdestinycomponenttypedependency = PropertyInfo.Value.ToString();
                                    break;
                                case "enum":
                                    _prop.ContainsEnumData = true;
                                    break;
                                case "x-enum-values":
                                    _prop.ContainsEnumData = true;
                                    break;
                                default:
                                    throw new Exception("New thing");
                            }
                        }
                        _schema.Properties.Add(_prop);
                    }
                    RawSchema.Add(_schema);
                }
            }

            foreach (var item in RawSchema)
            {
                string code = item.GenerateCode();
                Directory.CreateDirectory($"DestinyEntities/{item.Namespace}");
                Directory.CreateDirectory($"DestinyEntities/_NoNamespace");
                if (item.Namespace != "DestinySharp")
                {
                    File.WriteAllText($"DestinyEntities/{item.Namespace}/{item.Name}.cs", code);
                }
                else
                {
                    File.WriteAllText($"DestinyEntities/_NoNamespace/{item.Name}.cs", code);
                }
            }

            foreach (var Enum in Enums)
            {
                string code = Enum.GenerateCode();
                Directory.CreateDirectory($"DestinyEntities/_Enums/{Enum.Namespace}");
                Directory.CreateDirectory($"DestinyEntities/_Enums/_NoNamespace");
                if (Enum.Namespace != "DestinySharp")
                {
                    File.WriteAllText($"DestinyEntities/_Enums/{Enum.Namespace}/{Enum.ClassName}.cs", code);
                }
                else
                {
                    File.WriteAllText($"DestinyEntities/_Enums/_NoNamespace/{Enum.ClassName}.cs", code);
                }
            }

            string json = JsonConvert.SerializeObject(RawSchema);
            File.WriteAllText("rs_output.json", json);


            //List<string> types = new List<string>();
            //foreach (var item in RawSchema)
            //{
            //    foreach (var property in item.Properties)
            //    {
            //        if (!types.Contains(property.Type))
            //        {
            //            types.Add(property.Type);
            //        }
            //    }
            //}

            //json = JsonConvert.SerializeObject(types);
            //File.WriteAllText("types.json", json);

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
