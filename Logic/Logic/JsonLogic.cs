using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic
{
    public static class JsonLogic<T> where T: class
    {
        public static List<string> ListToJson(List<T> list)
        {
            List<string> json = new List<string>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    json.Add(JsonConvert.SerializeObject(item));
                }
            }
            return json;
        }
    }
}
