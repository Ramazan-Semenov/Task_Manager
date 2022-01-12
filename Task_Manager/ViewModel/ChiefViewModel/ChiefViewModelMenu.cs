using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Task_Manager.ViewModel.ChiefViewModel
{
    class ChiefViewModelMenu:ViewModelBase
    {
        private Page PageCurrent = new Page() { ShowsNavigationUI=false};
        private Page ChiefViewPage;
        public double FrameOpacity { get; set; } 
        public Page CurrentPage { get => PageCurrent; set { PageCurrent = value; RaisePropertyChanged(nameof(CurrentPage)); } }

        public ChiefViewModelMenu()
        {
            //PageCurrent = ChiefViewPage;
            //MessageBox.Show(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.Department == "Аналитика").Count().ToString());
            FrameOpacity = 1;
            //opendf = new RelayCommand(() => {
            //     PageCurrent = ChiefViewPage; RaisePropertyChanged("CurrentPage"); 
            //}) ;
        }
       
        public RelayCommand<string> opendf
        {
            get
            {
                return new RelayCommand<string>(( string department)=> {
                    ChiefViewPage = new View.ChiefView.ChiefViewPage(department);
                    PageCurrent = ChiefViewPage; RaisePropertyChanged("CurrentPage"); });
            }
        }
       
    }
}
