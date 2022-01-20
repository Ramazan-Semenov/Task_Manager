using System.Windows;

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorViewEditTask.xaml
    /// </summary>
    public partial class CoordinatorViewEditTask : Window
    {
        public CoordinatorViewEditTask(Model.task_book task_Book)
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorViewModelEditTask(task_Book);
        }
    }
}
