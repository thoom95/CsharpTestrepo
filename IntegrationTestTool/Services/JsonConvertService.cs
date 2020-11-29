using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTestTool.Services
{
    public class JsonConvertService
    {
        public string SerializeToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
