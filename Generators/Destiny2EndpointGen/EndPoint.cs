using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2EndpointGen
{
    public enum Verb
    {
        GET,
        POST
    }

    public class EndPoint
    {
        public string _Code;

        public string URL;
        public string Summary;
        public string Description;
        public List<string> Tags = new List<string>();
        public List<EndPointParameter> Parameters = new List<EndPointParameter>();
        public List<EndpointResponse> Responses = new List<EndpointResponse>();
        public bool IsPreview = false;
        public Verb Verb;
        [JsonProperty("POSTSchemaRef", NullValueHandling = NullValueHandling.Ignore)]
        public string POSTSchemaRef;
        [JsonProperty("RequestBody", NullValueHandling = NullValueHandling.Ignore)]
        public List<EndPointParameterSchema> RequestBodyItems = new List<EndPointParameterSchema>();


        public string GenerateCode()
        {
            string _code = $"public dynamic {Summary.Split('.').Last()}(ARGUMENTS)\r\n{{\r\n";
            _code = _code + "RestClient _client = new RestClient(\"http://www.bungie.net/d1/Platform/Destiny\");\r\n";
            _code = _code + $"var request = new RestRequest($\"{URL}\");\r\n";
            _code = _code + "request.AddHeader(\"X-API-KEY\", APIKey);\r\n";

            List<string> _summary = new List<string>();
            _summary.Add("///<summary>");
            _summary.Add($"{Description}");
            _summary.Add("///</summary>");


            string formattedparameters = "";
            if (Parameters.Count > 0)
            {
                foreach (var parameter in Parameters)
                {
                    _code = _code + $"request.AddParameter(\"{parameter.Name}\", {parameter.Name});\r\n";
                    switch (parameter.Schema.Type)
                    {
                        case "integer":
                            formattedparameters = formattedparameters + $"int {parameter.Name},";
                            _summary.Add($"/// <param name=\"{parameter.Name}\">{parameter.Description}</param>");
                            break;
                        case "string":
                            formattedparameters = formattedparameters + $"string {parameter.Name},";
                            _summary.Add($"/// <param name=\"{parameter.Name}\">{parameter.Description}</param>");
                            break;
                        case "boolean":
                            formattedparameters = formattedparameters + $"bool {parameter.Name},";
                            _summary.Add($"/// <param name=\"{parameter.Name}\">{parameter.Description}</param>");
                            break;
                        case "array":
                            formattedparameters = formattedparameters + $"object[] {parameter.Name},";
                            _summary.Add($"/// <param name=\"{parameter.Name}\">{parameter.Description}</param>");
                            break;
                        default:
                            if (parameter.Schema.Ref != null)
                            {
                                formattedparameters = formattedparameters + $"{parameter.Schema.Ref.Split(new string[] { "schemas/" }, StringSplitOptions.None).Last()} {parameter.Name},";
                                _summary.Add($"/// <param name=\"{parameter.Name}\">{parameter.Description}</param>");
                            }
                            else
                            {
                                throw new Exception("New thing");
                            }
                            break;
                    }
                }
            }
            //_summary.Add($"///<returns>{Responses.First().Ref.Split(new string[] { "responses" }, StringSplitOptions.None).Last()}</returns>");

            _code = _code + "var response = _client.Execute(request);\r\n";
            _code = _code + "dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);\r\n";
            _code = _code + "return deserializedResponse;\r\n";
            _code = _code + "}\r\n";

            if (formattedparameters != "")
            {
                _code = _code.Replace("ARGUMENTS", formattedparameters.Substring(0, (formattedparameters.Length - 1)));
            }
            else
            {
                _code = _code.Replace("ARGUMENTS", " ");
            }

            return _code;
        }

        //public ActivityData GetActivityHistoryStats(string membershipid, string characterId, MembershipType type,
        //   DestinyActivityMode activity, int count = 25, int page = 0, bool definitions = false)
        //{
        //    var request = new RestRequest($"/Stats/ActivityHistory/{(int)type}/{membershipid}/{characterId}/");
        //    request.AddHeader("X-API-KEY", Apikey);
        //    request.AddParameter("mode", activity);
        //    request.AddParameter("count", count);
        //    request.AddParameter("page", page);
        //    request.AddParameter("definitions", definitions);

        //    var response = _client.Execute(request);
        //    var r = JsonConvert.DeserializeObject<DestinyServiceObjectResponse<ActivityData>>(response.Content);
        //    return r.Response.data;
        //}

    }

    public class EndPointParameter
    {
        public string Name;
        public string Description;
        public string In;
        public EndPointParameterSchema Schema;
    }

    public class EndPointParameterSchema
    {
        [JsonProperty("Type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type;
        [JsonProperty("Format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format;
        [JsonProperty("$ref", NullValueHandling = NullValueHandling.Ignore)]
        public string Ref;
    }

    public class EndpointResponse
    {
        [JsonProperty("$ref")]
        public string Ref;
    }
}
