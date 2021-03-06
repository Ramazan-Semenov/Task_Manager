using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Task_Manager.ViewModel.ChiefViewModel
{
    class ChiefViewModelMenu : ViewModelBase
    {
        private Page PageCurrent = new Page() { ShowsNavigationUI = false };
        private Page ChiefViewPage;
        public double FrameOpacity { get; set; }
        public Page CurrentPage { get => PageCurrent; set { PageCurrent = value; RaisePropertyChanged(nameof(CurrentPage)); } }

        public ChiefViewModelMenu()
        {
            FrameOpacity = 1;

            tabItemsource = new List<TabItem>();
           
        }
        private List<TabItem> tabItemsource;
        public List<TabItem> TabItemSource { get; set; } = new List<TabItem>() { new TabItem { Header = "Развитие отчетности и разработка" } };

        public Visibility visibility
        {
            get; set;
        } = Visibility.Visible;
  
        public RelayCommand<string> click
        {
            get
            {
                return new RelayCommand<string>((string h) =>
                {
                    ChiefViewPage = new View.Coordinator.CoordinatorViewPage(h);
                    PageCurrent = ChiefViewPage; RaisePropertyChanged("CurrentPage");


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
