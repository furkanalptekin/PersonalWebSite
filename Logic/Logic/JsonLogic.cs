using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic
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
