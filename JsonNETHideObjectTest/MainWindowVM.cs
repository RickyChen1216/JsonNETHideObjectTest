using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace JsonNETHideObjectTest
{
    public class MainWindowVM
    {
        public MainWindowVM()
        {
            try
            {
                var vm = AnnotationViewModel.ReadJsonFile("..\\..\\..\\test.json", new Resolver());
                MessageBox.Show(JsonConvert.SerializeObject(vm, AnnotationViewModel.JsonSettings()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
