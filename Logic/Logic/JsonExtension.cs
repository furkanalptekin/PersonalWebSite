using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic
{
    public static class JsonExtension
    {
        public static List<string> ToJsonList<T>(this List<T> list) where T : class
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

        public static string ToJson<T>(this List<T> list) where T : class
        {
            string json = null;
            if (list != null)
                json = JsonConvert.SerializeObject(list);
            return json;
        }
    }
}