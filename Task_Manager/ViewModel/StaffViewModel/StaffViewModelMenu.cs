using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace Task_Manager.ViewModel.StaffViewModel
{
    public class StaffViewModelMenu : ViewModelBase
    {
        private Page PageCurrent = new Page();
        private Page StaffViewPage = new View.StaffView.StaffViewPage();
        public double FrameOpacity { get; set; } = 1;
        public Page CurrentPage { get => PageCurrent; set { PageCurrent = value; RaisePropertyChanged(nameof(CurrentPage)); } }

        public StaffViewModelMenu()
        {

            //PageCurrent = StaffViewPage;
        }


        public RelayCommand MainPage
        {
            get
            {
                return new RelayCommand(()=> { PageCurrent = StaffViewPage; RaisePropertyChanged(nameof(CurrentPage)); });
            }
        } 
        public RelayCommand Outgoing_tasks_Command
        {
            get
            {
                return new RelayCommand(()=> { PageCurrent = new View.StaffView.Outgoing_tasks(); RaisePropertyChanged(nameof(CurrentPage)); });
            }
        }
        public RelayCommand OpenDiagramm
        {
            get
            {
                return new RelayCommand(()=> { PageCurrent = new View.StaffView.StaffDiagramView(); RaisePropertyChanged(nameof(CurrentPage)); });
            }
        }
    }
}
