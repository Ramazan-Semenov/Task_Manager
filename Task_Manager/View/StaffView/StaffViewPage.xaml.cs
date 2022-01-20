using System.Windows.Controls;

namespace Task_Manager.View.StaffView
{
    /// <summary>
    /// Логика взаимодействия для StaffViewPage.xaml
    /// </summary>
    public partial class StaffViewPage : Page
    {
        public StaffViewPage()
        {
            InitializeComponent();
            // DataContext = ViewModel.StaffViewModel.LinkPage_CreateTask.modelPage;

            DataContext = new ViewModel.StaffViewModel.StaffViewModelPage();
        }
    }
}
