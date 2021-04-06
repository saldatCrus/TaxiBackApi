using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductManagerApplication.ViewModels
{
    class ShowLogViewModel : BindableBase
    {
        public ShowLogViewModel() 
        {

        }


        public ICommand GetAllLog => new DelegateCommand(() =>
        {
           
        }); // кнопка для получения всех логов
    }  
}
