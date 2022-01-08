using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.StaffViewModel
{
  public  class StaffViewModelMenu: ViewModelBase
    {
        private Page PageCurrent = new Page();
        private Page StaffViewPage = new View.StaffView.StaffViewPage();
        public double FrameOpacity { get; set; } = 1;
        public Page CurrentPage { get => PageCurrent; set { PageCurrent = value; RaisePropertyChanged(nameof(CurrentPage)); } }

        public StaffViewModelMenu()
        {

            PageCurrent = StaffViewPage;
        }

   

    }
}
