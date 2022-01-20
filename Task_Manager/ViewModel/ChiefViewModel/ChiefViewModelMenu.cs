using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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


        }

        public RelayCommand<string> opendf
        {
            get
            {
                return new RelayCommand<string>((string department) =>
                {
                    ChiefViewPage = new View.ChiefView.ChiefViewPage(department);
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
                    PageCurrent = new View.ChiefView.create_request_template();
                    RaisePropertyChanged("CurrentPage");
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
