using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNETHideObjectTest
{
    public class MainWindowVM
    {
        public MainWindowVM()
        {
            try
            {
                AnnotationViewModel.ReadJsonFile("C:\\Users\\Ricky\\source\\repos\\JsonNETHideObjectTest\\test.json", new Resolver());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
