using GalaSoft.MvvmLight;
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

            PageCurrent = StaffViewPage;
        }



    }
}
