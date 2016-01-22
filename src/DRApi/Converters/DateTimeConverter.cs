using System;
using Newtonsoft.Json;

namespace DrApi.Converters {
    public class DateTimeConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime dt;
            dt = DateTime.Parse(reader.Value.ToString());                           
            return dt;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime dt =  (DateTime) value;
                        
            writer.WriteValue(dt.ToString());
        }
    }
}