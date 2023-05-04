using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JsonNETHideObjectTest.Resolver;

namespace JsonNETHideObjectTest
{
    partial class AnnotationViewModel
    {
        public static JsonSerializerSettings JsonSettings()
        {
            return new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
        }

        //https://stackoverflow.com/a/19717451/288936
        public class MShapeConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(MShape).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var token = JToken.Load(reader);
                if (token.Type == JTokenType.Object)
                {
                    // TODO: Ignore validation
                    var shapeType = token["$type"].Value<string>().Split(',').First().Split('.').Last();
                    switch (shapeType)
                    {
                        case nameof(MCircle):
                            break;
                        case nameof(MRectangle):
                            return token.ToObject<MRectangle>();
                        case nameof(MPolygon):
                            return token.ToObject<MPolygon>();
                        default:
                            throw new NotImplementedException();
                    }
                }
                return null;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        internal static AnnotationViewModel ReadJsonFile(string filename, IReferenceResolver resolver)
        {
            AnnotationViewModel annotationViewModel;

            annotationViewModel = JsonConvert.DeserializeObject<AnnotationViewModel>(
                File.ReadAllText(filename), new MShapeConverter());
            if (annotationViewModel == null)
            {
                throw new Exception("Empty json file.");
            }
            foreach (var vm in annotationViewModel.Objects)
            {
                vm.Layers.Where(o => o?.Shape == null).ToList().ForEach(o => vm.Layers.Remove(o));
            }
            return annotationViewModel;
        }
    }
}
