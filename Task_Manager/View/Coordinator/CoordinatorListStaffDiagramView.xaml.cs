using System.Windows.Controls;

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorListStaffDiagramView.xaml
    /// </summary>
    public partial class CoordinatorListStaffDiagramView : Page
    {
        public CoordinatorListStaffDiagramView()
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorListStaffDiagramViewModel();
        }


    }
}
