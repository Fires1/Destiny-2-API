using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2ApiGenerator
{
    public class NewEnum
    {
        public string Name; //`RawName` in scheme
        public string ClassName; //`Name` in Schema
        public string Namespace = "DestinySharp";
        public string Code;
        public Dictionary<int, string> EnumValues;


        public void GenerateNamespace()
        {
            string[] splitname = Name.Split('.');
            this.ClassName = splitname.Last();
            if (Name.Contains('.'))
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
            string Base = @"namespace {this.Namespace}
{
        public enum {this.name}
    {
";
            #endregion

            string _code = Base;

            foreach (var EnumEntry in this.EnumValues)
            {
                string enumv = $"{EnumEntry.Value} = {EnumEntry.Key},\r\n";
                _code = _code + enumv;
            }
            _code = _code + "}\r\n}";

                _code = _code.Replace("{this.Namespace}", this.Namespace);
            
            _code = _code.Replace("{this.name}", this.ClassName);
            this.Code = _code;
            return _code;
        }
    }
}
