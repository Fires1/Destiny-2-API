using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseSchemaGen
{
    public class RawSchema
    {
        public string Namespace = "DestinySharp";
        public string Name;
        public string RawName;
        public List<SchemaProperty> Properties = new List<SchemaProperty>();
        public string Code;
        [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description;

        public void GenerateNamespace()
        {
            string[] splitname = RawName.Split('.');
            this.Name = splitname.Last();
            if (RawName.Contains('.'))
            {
                this.Namespace = string.Join(".", splitname.Take(splitname.Count() - 1));
            }
            else
            {
                this.Namespace = "DestinySharp";
            }
        }

        public string GenerateCode()
        {
            #region Base
            string Base = @"
using System;
using System.Collections.Generic;
using DestinySharp;

namespace {this.Namespace}
{
    public class {this.Name}
    {
";
            #endregion

            string _code = Base;

            foreach (SchemaProperty property in this.Properties)
            {
                string _formattedProperty = "public ";

                if (property.Ref != null)
                {
                    string[] split = property.Ref.Split(new string[] { "schemas" }, StringSplitOptions.None);
                    if (!property.Ref.Contains('.'))
                    {
                        _formattedProperty = _formattedProperty + " DestinySharp." + split.Last().TrimStart('/') + " ";
                    }
                    else
                    {
                        _formattedProperty = _formattedProperty + split.Last().TrimStart('/') + " ";
                    }
                    _formattedProperty = _formattedProperty + property.Name + ";\r\n";
                    _code = _code + _formattedProperty;
                    continue;
                }

                switch (property.Type)
                {
                    case "integer":
                        _formattedProperty = _formattedProperty + "int ";
                        break;
                    case "string":
                        _formattedProperty = _formattedProperty + "string ";
                        break;
                    case "boolean":
                        _formattedProperty = _formattedProperty + "bool ";
                        break;
                    case "array":
                        _formattedProperty = _formattedProperty + "List<object> ";
                        break;
                    case "number":
                        _formattedProperty = _formattedProperty + "decimal ";
                        break;
                    default:
                        continue;
                }
                _formattedProperty = _formattedProperty + property.Name + ";\r\n";
                _code = _code + _formattedProperty;
            }
            _code = _code + "}\r\n}";
            _code = _code.Replace("{this.Namespace}", this.Namespace);
            _code = _code.Replace("{this.Name}", this.Name);
            this.Code = _code;
            return _code;
        }
    }

    public class SchemaProperty
    {
        public string Name;
        [JsonProperty("Type", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        //Known Formats:
        //Int64
        //uint32 (i believe long or ulong would work aswell)
        public string Type;
        [JsonProperty("Format", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        //Known formats:
        //date-time
        public string Format;
        [JsonProperty("Nullable", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Nullable;
        [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description;



        [JsonProperty("$ref", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Ref;
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<object> Items;
        [JsonProperty("allOf", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<object> AllOf;
        [JsonProperty("additionalProperties", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        //Occurs when Type == "object"
        public List<object> AdditionalProperties;
        [JsonProperty("x-dictionary-key", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<object> XDictionaryKey;
        [JsonProperty("x-mapped-definition", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<object> XMappedDefinition;
        [JsonProperty("x-destiny-component-type-dependency", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string xdestinycomponenttypedependency;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ContainsEnumData;

    }
}
