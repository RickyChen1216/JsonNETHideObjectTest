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
    public partial class AnnotationViewModel : ViewModelBase
    {
        public AnnotationViewModel()
        {
        }

        private int _id;
        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        private ObservableCollection<AnnotationObjectViewModel> _objects = new ObservableCollection<AnnotationObjectViewModel>();
        [JsonProperty]
        public ObservableCollection<AnnotationObjectViewModel> Objects
        {
            get => _objects;
            set => Set(ref _objects, value);
        }
    }
}
