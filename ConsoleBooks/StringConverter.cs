﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleBooks
{
    class StringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                return new List<string>() {
                    (string)reader.Value
                };
            }
            return serializer.Deserialize<List<string>>(reader);
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
