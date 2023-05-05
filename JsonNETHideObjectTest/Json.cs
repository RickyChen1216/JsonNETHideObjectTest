using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        internal static AnnotationViewModel ReadJsonFile(string filename, IReferenceResolver resolver)
        {
            AnnotationViewModel annotationViewModel = 
                JsonConvert.DeserializeObject<AnnotationViewModel>(
                File.ReadAllText(filename), JsonSettings());
            if (annotationViewModel == null)
            {
                throw new Exception("Empty json file.");
            }
            foreach (var vm in annotationViewModel.Objects)
            {
                vm.Layers = new ObservableCollection<LayerViewModel>(
                    vm.Layers.Where(o => !(o?.Shape is MCircle)));
            }
            annotationViewModel.Objects =
                new ObservableCollection<AnnotationObjectViewModel>(
                    annotationViewModel.Objects.Where(o => o.Layers.Any()));
            return annotationViewModel;
        }
    }
}
