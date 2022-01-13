using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
    class CoordinatorViewModelMenu : ViewModelBase
    {
        private Page PageCurrent = new Page() { ShowsNavigationUI = false };
        private Page ChiefViewPage;
        public double FrameOpacity { get; set; }
        public Page CurrentPage { get => PageCurrent; set { PageCurrent = value; RaisePropertyChanged(nameof(CurrentPage)); } }

        public CoordinatorViewModelMenu()
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
                return new RelayCommand<string>((string department) => {
                    ChiefViewPage = new View.Coordinator.CoordinatorViewPage(department);
                    PageCurrent = ChiefViewPage; RaisePropertyChanged("CurrentPage");
                });
            }
        }
        public RelayCommand create_request
        {
            get
            {
                return new RelayCommand(() => {
                    PageCurrent = new View.ChiefView.create_request_template();
                    RaisePropertyChanged("CurrentPage");
                });

            }
        }
        public RelayCommand opendiagram
        {
            get
            {
                return new RelayCommand(() => {
                    PageCurrent = new View.DiagramGantt.DiagramGanttView();
                    RaisePropertyChanged("CurrentPage");
                });

            }
        }

    }
}
