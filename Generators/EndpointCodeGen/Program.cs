using Destiny2EndpointGen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointCodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EndPoint> endpoints = new List<EndPoint>();
            endpoints = new EndpointGen().GetEndpoints();

            File.WriteAllText("endpoints/Main.cs", "using Newtonsoft.Json;\r\nusing RestSharp;\r\n namespace DestinySharp {\r\n\tpublic class BungieClient {\r\n");

            foreach (var endpoint in endpoints)
            {
                string code = endpoint.GenerateCode();
                Directory.CreateDirectory("endpoints/");
                using(StreamWriter sw = File.AppendText("endpoints/Main.cs"))
                {
                    sw.WriteLine("\r\n" +code);
                }
            }
            using (StreamWriter sw = File.AppendText("endpoints/Main.cs"))
            {
                sw.WriteLine("\t}\r\n}");
            }

            Console.WriteLine("Finished.");
            Console.ReadLine();
        }
    }
}
