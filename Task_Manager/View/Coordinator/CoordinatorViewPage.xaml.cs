using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorViewPage.xaml
    /// </summary>
    public partial class CoordinatorViewPage : Page
    {

        public CoordinatorViewPage(string department)
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorViewModelPage(department);

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Ok");
        }
    }
}
