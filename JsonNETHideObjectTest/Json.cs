using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal static JsonSerializerSettings JsonSettings(IReferenceResolver resolver)
        {
            var settings = JsonSettings();
            //settings.ReferenceResolverProvider = () => resolver;
            //settings.ContractResolver = new DynamicContractResolver();
            return settings;
        }

        internal static AnnotationViewModel ReadJsonFile(string filename, IReferenceResolver resolver)
        {
            AnnotationViewModel annotationViewModel;

            var jsonSerializer = JsonSerializer.Create(JsonSettings(resolver));

            using (var streamReader = File.OpenText(filename))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                annotationViewModel = jsonSerializer.Deserialize<AnnotationViewModel>(jsonTextReader);
            }

            if (annotationViewModel == null)
            {
                throw new Exception("Empty json file.");
            }

            return annotationViewModel;
        }
    }
}
