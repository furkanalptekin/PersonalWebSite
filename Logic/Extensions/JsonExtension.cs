using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic.Extensions
{
    public static class JsonExtension
    {
        /// <summary>
        /// Verilen listeyi jsona çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns><see cref="IList{T}"/> T: <see cref="string"/></returns>
        public static IList<string> ToJsonList<T>(this IList<T> list) where T : class
        {
            var json = new List<string>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    json.Add(JsonConvert.SerializeObject(item));
                }
            }
            return json;
        }

        /// <summary>
        /// Verilen listeyi jsona çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns><see cref="string"/></returns>
        public static string ToJson<T>(this IList<T> list) where T : class
        {
            string json = null;
            if (list != null)
                json = JsonConvert.SerializeObject(list);

            return json;
        }
    }
}