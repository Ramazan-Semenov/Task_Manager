using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
    class CoordinatorViewModelMenu : ViewModelBase
    {
        private Page PageCurrent = new Page() { ShowsNavigationUI = false };
        private Page ChiefViewPage;
        public Visibility visibility
        {
            get; set;
        } = Visibility.Visible;
        public Page CurrentPage { get => PageCurrent; set { PageCurrent = value; RaisePropertyChanged(nameof(CurrentPage)); } }

        public CoordinatorViewModelMenu()
        {
            //PageCurrent = ChiefViewPage;
            //MessageBox.Show(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.Department == "Аналитика").Count().ToString());
            //opendf = new RelayCommand(() => {
            //     PageCurrent = ChiefViewPage; RaisePropertyChanged("CurrentPage"); 
            //}) ;


        }
        public RelayCommand<string> click
        {
            get
            {
                return new RelayCommand<string>((string h) =>
                {
                    ChiefViewPage = new View.Coordinator.CoordinatorViewPage(h);
                    PageCurrent = ChiefViewPage; RaisePropertyChanged("CurrentPage");
                    //B = new List<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.Department == h));
                    //ListStaff = B.GroupBy(x => x.executor).Select(x => x.Key).Where(x => x != null).ToList();
                    //RaisePropertyChanged("ListStaff");
                    //RaisePropertyChanged("B");

                }); ;
            }
        }
        public RelayCommand<string> opendf
        {
            get
            {
                return new RelayCommand<string>((string department) =>
                {
                    ChiefViewPage = new View.Coordinator.CoordinatorViewPage(department);
                    PageCurrent = ChiefViewPage; RaisePropertyChanged("CurrentPage");
                });
            }
        }
        public RelayCommand create_request
        {
            get
            {
                return new RelayCommand(() =>
                {
                    visibility = Visibility.Collapsed;

                    PageCurrent = new View.ChiefView.create_request_template();
                    RaisePropertyChanged("CurrentPage");
                    RaisePropertyChanged("visibility");
                });

            }
        }
        public RelayCommand main_menu
        {
            get
            {
                return new RelayCommand(() =>
                {
                    visibility = Visibility.Visible;

                    PageCurrent = null;
                    RaisePropertyChanged("CurrentPage");
                    RaisePropertyChanged("visibility");
                });

            }
        }
        public RelayCommand ListStaffDiagramCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    visibility = Visibility.Collapsed;
                    PageCurrent = new View.Coordinator.CoordinatorListStaffDiagramView();
                    RaisePropertyChanged("CurrentPage");
                    RaisePropertyChanged("visibility");

                });

            }
        }
        public RelayCommand opendiagram
        {
            get
            {
                return new RelayCommand(() =>
                {
                    PageCurrent = new View.ChiefView.create_request_template();
                    RaisePropertyChanged("CurrentPage");
                });

            }
        }

    }
}
