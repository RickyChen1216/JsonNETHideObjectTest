using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNETHideObjectTest
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AnnotationObjectViewModel : ViewModelBase
    {
        public AnnotationObjectViewModel()
        {
        }

        private int _fontsize = 20;
        public int Fontsize
        {
            get => _fontsize;
            set => Set(ref _fontsize, value);
        }

        private string _class;
        [JsonProperty]
        public string Class
        {
            get => _class;
            set => Set(ref _class, value);
        }

        private string _name;
        [JsonProperty]
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private ObservableCollection<LayerViewModel> _layers = new ObservableCollection<LayerViewModel>();
        [JsonProperty]
        public ObservableCollection<LayerViewModel> Layers
        {
            get => _layers;
            set => Set(ref _layers, value);
        }
    }
}
