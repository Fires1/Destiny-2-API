using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Destiny2EndpointGen
{
    public class EndpointGen
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("openapi.json");
            dynamic BaseJson = JsonConvert.DeserializeObject<dynamic>(text);
            List<EndPoint> FinishedEndpoints = new List<EndPoint>();

            foreach (dynamic Path in BaseJson.paths)
            {
                EndPoint _endpoint = new EndPoint();
                foreach (var Entries in Path)
                {
                    foreach (JProperty Entry in Entries)
                    {
                        switch (Entry.Name)
                        {
                            case "summary":
                                _endpoint.Summary = Entry.Value.ToString();
                                _endpoint.URL = Path.Name;
                                break;
                            case "description":
                                _endpoint.Description = Entry.Value.ToString();
                                break;
                            case "get":
                                _endpoint.Verb = Verb.GET;
                                foreach (var Get in Entry)
                                {
                                    foreach (dynamic Token in Get)
                                    {
                                        switch (Token.Name)
                                        {
                                            case "tags":
                                                foreach (var TagArray in Token)
                                                {
                                                    foreach (var tag in TagArray)
                                                    {
                                                        _endpoint.Tags.Add(tag.Value);
                                                    }
                                                }
                                                break;
                                            case "description":
                                                break;
                                            case "operationId":
                                                break;
                                            case "parameters":
                                                if (Token.First.Count > 0)
                                                {
                                                    foreach (var Params in Token)
                                                    {
                                                        foreach (var Parameter in Params)
                                                        {
                                                            EndPointParameter parameter = new EndPointParameter();
                                                            foreach (var ParameterInfo in Parameter)
                                                            {
                                                                switch (ParameterInfo.Name)
                                                                {
                                                                    case "name":
                                                                        parameter.Name = ParameterInfo.Value;
                                                                        break;
                                                                    case "in":
                                                                        parameter.In = ParameterInfo.Value;
                                                                        break;
                                                                    case "description":
                                                                        parameter.Description = ParameterInfo.Value;
                                                                        break;
                                                                    case "required":
                                                                        break;
                                                                    case "schema":
                                                                        foreach (var schema in ParameterInfo)
                                                                        {
                                                                            EndPointParameterSchema _schema = new EndPointParameterSchema();
                                                                            bool ExitLoop = false;
                                                                            foreach (var schemeInfo in schema)
                                                                            {
                                                                                switch (schemeInfo.Name)
                                                                                {
                                                                                    case "$ref":
                                                                                        ExitLoop = true;
                                                                                        _schema.Ref = schemeInfo.Value;
                                                                                        break;
                                                                                    case "type":
                                                                                        _schema.Type = schemeInfo.Value;
                                                                                        break;
                                                                                    case "format":
                                                                                        _schema.Format = schemeInfo.Value;
                                                                                        break;
                                                                                }
                                                                                if (ExitLoop) { break; }
                                                                            }
                                                                            parameter.Schema = _schema;
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                            _endpoint.Parameters.Add(parameter);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "x-preview":
                                                _endpoint.IsPreview = true;
                                                break;
                                            case "responses":
                                                foreach (var BaseResponses in Token)
                                                {
                                                    EndpointResponse response = new EndpointResponse();
                                                    foreach (var Responses in BaseResponses)
                                                    {
                                                        foreach (var ResponseInfo in Responses)
                                                        {
                                                            foreach (var Ref in ResponseInfo)
                                                            {
                                                                response.Ref = Ref.Value;
                                                            }
                                                        }
                                                    }
                                                    _endpoint.Responses.Add(response);
                                                }
                                                break;
                                        }
                                    }
                                }
                                break;

                            case "post":
                                _endpoint.Verb = Verb.POST;
                                foreach (var Get in Entry)
                                {
                                    foreach (dynamic Token in Get)
                                    {
                                        switch (Token.Name)
                                        {
                                            case "tags":
                                                foreach (var TagArray in Token)
                                                {
                                                    foreach (var tag in TagArray)
                                                    {
                                                        _endpoint.Tags.Add(tag.Value);
                                                    }
                                                }
                                                break;
                                            case "description":
                                                break;
                                            case "operationId":
                                                break;
                                                //Unlikely to have nay parameters though.
                                            case "parameters":
                                                if (Token.First.Count > 0)
                                                {
                                                    foreach (var Params in Token)
                                                    {
                                                        foreach (var Parameter in Params)
                                                        {
                                                            EndPointParameter parameter = new EndPointParameter();
                                                            foreach (var ParameterInfo in Parameter)
                                                            {
                                                                switch (ParameterInfo.Name)
                                                                {
                                                                    case "name":
                                                                        parameter.Name = ParameterInfo.Value;
                                                                        break;
                                                                    case "in":
                                                                        parameter.In = ParameterInfo.Value;
                                                                        break;
                                                                    case "description":
                                                                        parameter.Description = ParameterInfo.Value;
                                                                        break;
                                                                    case "required":
                                                                        break;
                                                                    case "schema":
                                                                        foreach (var schema in ParameterInfo)
                                                                        {
                                                                            EndPointParameterSchema _schema = new EndPointParameterSchema();
                                                                            bool ExitLoop = false;
                                                                            foreach (var schemeInfo in schema)
                                                                            {
                                                                                switch (schemeInfo.Name)
                                                                                {
                                                                                    case "$ref":
                                                                                        ExitLoop = true;
                                                                                        _schema.Ref = schemeInfo.Value;
                                                                                        break;
                                                                                    case "type":
                                                                                        _schema.Type = schemeInfo.Value;
                                                                                        break;
                                                                                    case "format":
                                                                                        _schema.Format = schemeInfo.Value;
                                                                                        break;
                                                                                }
                                                                                if (ExitLoop) { break; }
                                                                            }
                                                                            parameter.Schema = _schema;
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                            _endpoint.Parameters.Add(parameter);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "x-preview":
                                                _endpoint.IsPreview = true;
                                                break;
                                            case "responses":
                                                foreach (var BaseResponses in Token)
                                                {
                                                    EndpointResponse response = new EndpointResponse();
                                                    foreach (var Responses in BaseResponses)
                                                    {
                                                        foreach (var ResponseInfo in Responses)
                                                        {
                                                            foreach (var Ref in ResponseInfo)
                                                            {
                                                                response.Ref = Ref.Value;
                                                            }
                                                        }
                                                    }
                                                    _endpoint.Responses.Add(response);
                                                }
                                                break;
                                            case "requestBody":
                                                foreach (JObject BaseRequest in Token)
                                                {
                                                    foreach (JProperty obj in BaseRequest.First.First.First.First.First.First)
                                                    {
                                                        switch (obj.Name)
                                                        {
                                                            case "type":
                                                                break;
                                                            case "items":
                                                                EndPointParameterSchema sche = new EndPointParameterSchema();
                                                                foreach (JProperty Item in obj.First)
                                                                {
                                                                    switch (Item.Name)
                                                                    {
                                                                        case "$ref":
                                                                            sche.Ref = Item.Value.ToString();
                                                                            break;
                                                                        case "type":
                                                                            sche.Type = Item.Value.ToString();
                                                                            break;
                                                                        case "format":
                                                                            sche.Format = Item.Value.ToString();
                                                                            break;
                                                                    }
                                                                }
                                                                _endpoint.RequestBodyItems.Add(sche);
                                                                break;
                                                            case "$ref":
                                                                _endpoint.POSTSchemaRef = obj.Value.ToString();
                                                                break;
                                                        }
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
                FinishedEndpoints.Add(_endpoint);
            }
            string json = JsonConvert.SerializeObject(FinishedEndpoints);
            File.WriteAllText("output.json", json);
            Console.WriteLine("Finished.");
            Console.ReadLine();
        }

        public List<EndPoint> GetEndpoints()
        {
            string text = File.ReadAllText("openapi.json");
            dynamic BaseJson = JsonConvert.DeserializeObject<dynamic>(text);
            List<EndPoint> FinishedEndpoints = new List<EndPoint>();

            foreach (dynamic Path in BaseJson.paths)
            {
                EndPoint _endpoint = new EndPoint();
                foreach (var Entries in Path)
                {
                    foreach (JProperty Entry in Entries)
                    {
                        switch (Entry.Name)
                        {
                            case "summary":
                                _endpoint.Summary = Entry.Value.ToString();
                                _endpoint.URL = Path.Name;
                                break;
                            case "description":
                                _endpoint.Description = Entry.Value.ToString();
                                break;
                            case "get":
                                _endpoint.Verb = Verb.GET;
                                foreach (var Get in Entry)
                                {
                                    foreach (dynamic Token in Get)
                                    {
                                        switch (Token.Name)
                                        {
                                            case "tags":
                                                foreach (var TagArray in Token)
                                                {
                                                    foreach (var tag in TagArray)
                                                    {
                                                        _endpoint.Tags.Add(tag.Value);
                                                    }
                                                }
                                                break;
                                            case "description":
                                                break;
                                            case "operationId":
                                                break;
                                            case "parameters":
                                                if (Token.First.Count > 0)
                                                {
                                                    foreach (var Params in Token)
                                                    {
                                                        foreach (var Parameter in Params)
                                                        {
                                                            EndPointParameter parameter = new EndPointParameter();
                                                            foreach (var ParameterInfo in Parameter)
                                                            {
                                                                switch (ParameterInfo.Name)
                                                                {
                                                                    case "name":
                                                                        parameter.Name = ParameterInfo.Value;
                                                                        break;
                                                                    case "in":
                                                                        parameter.In = ParameterInfo.Value;
                                                                        break;
                                                                    case "description":
                                                                        parameter.Description = ParameterInfo.Value;
                                                                        break;
                                                                    case "required":
                                                                        break;
                                                                    case "schema":
                                                                        foreach (var schema in ParameterInfo)
                                                                        {
                                                                            EndPointParameterSchema _schema = new EndPointParameterSchema();
                                                                            bool ExitLoop = false;
                                                                            foreach (var schemeInfo in schema)
                                                                            {
                                                                                switch (schemeInfo.Name)
                                                                                {
                                                                                    case "$ref":
                                                                                        ExitLoop = true;
                                                                                        _schema.Ref = schemeInfo.Value;
                                                                                        break;
                                                                                    case "type":
                                                                                        _schema.Type = schemeInfo.Value;
                                                                                        break;
                                                                                    case "format":
                                                                                        _schema.Format = schemeInfo.Value;
                                                                                        break;
                                                                                }
                                                                                if (ExitLoop) { break; }
                                                                            }
                                                                            parameter.Schema = _schema;
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                            _endpoint.Parameters.Add(parameter);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "x-preview":
                                                _endpoint.IsPreview = true;
                                                break;
                                            case "responses":
                                                foreach (var BaseResponses in Token)
                                                {
                                                    EndpointResponse response = new EndpointResponse();
                                                    foreach (var Responses in BaseResponses)
                                                    {
                                                        foreach (var ResponseInfo in Responses)
                                                        {
                                                            foreach (var Ref in ResponseInfo)
                                                            {
                                                                response.Ref = Ref.Value;
                                                            }
                                                        }
                                                    }
                                                    _endpoint.Responses.Add(response);
                                                }
                                                break;
                                        }
                                    }
                                }
                                break;

                            case "post":
                                _endpoint.Verb = Verb.POST;
                                foreach (var Get in Entry)
                                {
                                    foreach (dynamic Token in Get)
                                    {
                                        switch (Token.Name)
                                        {
                                            case "tags":
                                                foreach (var TagArray in Token)
                                                {
                                                    foreach (var tag in TagArray)
                                                    {
                                                        _endpoint.Tags.Add(tag.Value);
                                                    }
                                                }
                                                break;
                                            case "description":
                                                break;
                                            case "operationId":
                                                break;
                                            //Unlikely to have nay parameters though.
                                            case "parameters":
                                                if (Token.First.Count > 0)
                                                {
                                                    foreach (var Params in Token)
                                                    {
                                                        foreach (var Parameter in Params)
                                                        {
                                                            EndPointParameter parameter = new EndPointParameter();
                                                            foreach (var ParameterInfo in Parameter)
                                                            {
                                                                switch (ParameterInfo.Name)
                                                                {
                                                                    case "name":
                                                                        parameter.Name = ParameterInfo.Value;
                                                                        break;
                                                                    case "in":
                                                                        parameter.In = ParameterInfo.Value;
                                                                        break;
                                                                    case "description":
                                                                        parameter.Description = ParameterInfo.Value;
                                                                        break;
                                                                    case "required":
                                                                        break;
                                                                    case "schema":
                                                                        foreach (var schema in ParameterInfo)
                                                                        {
                                                                            EndPointParameterSchema _schema = new EndPointParameterSchema();
                                                                            bool ExitLoop = false;
                                                                            foreach (var schemeInfo in schema)
                                                                            {
                                                                                switch (schemeInfo.Name)
                                                                                {
                                                                                    case "$ref":
                                                                                        ExitLoop = true;
                                                                                        _schema.Ref = schemeInfo.Value;
                                                                                        break;
                                                                                    case "type":
                                                                                        _schema.Type = schemeInfo.Value;
                                                                                        break;
                                                                                    case "format":
                                                                                        _schema.Format = schemeInfo.Value;
                                                                                        break;
                                                                                }
                                                                                if (ExitLoop) { break; }
                                                                            }
                                                                            parameter.Schema = _schema;
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                            _endpoint.Parameters.Add(parameter);
                                                        }
                                                    }
                                                }
                                                break;
                                            case "x-preview":
                                                _endpoint.IsPreview = true;
                                                break;
                                            case "responses":
                                                foreach (var BaseResponses in Token)
                                                {
                                                    EndpointResponse response = new EndpointResponse();
                                                    foreach (var Responses in BaseResponses)
                                                    {
                                                        foreach (var ResponseInfo in Responses)
                                                        {
                                                            foreach (var Ref in ResponseInfo)
                                                            {
                                                                response.Ref = Ref.Value;
                                                            }
                                                        }
                                                    }
                                                    _endpoint.Responses.Add(response);
                                                }
                                                break;
                                            case "requestBody":
                                                foreach (JObject BaseRequest in Token)
                                                {
                                                    foreach (JProperty obj in BaseRequest.First.First.First.First.First.First)
                                                    {
                                                        switch (obj.Name)
                                                        {
                                                            case "type":
                                                                break;
                                                            case "items":
                                                                EndPointParameterSchema sche = new EndPointParameterSchema();
                                                                foreach (JProperty Item in obj.First)
                                                                {
                                                                    switch (Item.Name)
                                                                    {
                                                                        case "$ref":
                                                                            sche.Ref = Item.Value.ToString();
                                                                            break;
                                                                        case "type":
                                                                            sche.Type = Item.Value.ToString();
                                                                            break;
                                                                        case "format":
                                                                            sche.Format = Item.Value.ToString();
                                                                            break;
                                                                    }
                                                                }
                                                                _endpoint.RequestBodyItems.Add(sche);
                                                                break;
                                                            case "$ref":
                                                                _endpoint.POSTSchemaRef = obj.Value.ToString();
                                                                break;
                                                        }
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
                FinishedEndpoints.Add(_endpoint);
            }

            return FinishedEndpoints;
        }
    }
}
