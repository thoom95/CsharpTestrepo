using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Services
{
    public class JsonConvertService
    {
        public string SerializeToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
