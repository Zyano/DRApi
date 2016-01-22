using System;
using Newtonsoft.Json;

namespace DrApi.Converters 
{
    public class UriConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            String u = (string) reader.Value;
            Uri u2 = new Uri(u);
            return u2;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Uri u = (Uri) value;
            writer.WriteValue(u.AbsolutePath.ToString());
        }
    }
}