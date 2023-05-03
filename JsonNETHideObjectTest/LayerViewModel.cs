using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNETHideObjectTest
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LayerViewModel : ViewModelBase
    {
        public LayerViewModel()
        {
        }

        private int _id;
        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        private int _drawMode;
        [JsonProperty]
        public int DrawMode
        {
            get => _drawMode;
            set => Set(ref _drawMode, value);
        }

        MShape _shape;
        [JsonProperty]
        public MShape Shape
        {
            get => _shape;
            set => Set(ref _shape, value);
        }
    }
}
