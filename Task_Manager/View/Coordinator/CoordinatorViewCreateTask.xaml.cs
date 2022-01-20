using System.Windows;

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorViewCreateTask.xaml
    /// </summary>
    public partial class CoordinatorViewCreateTask : Window
    {
        public CoordinatorViewCreateTask()
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorViewModelCreateTask();
        }
        public CoordinatorViewCreateTask(Model.task_book task_Book)
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorViewModelCreateTask(task_Book);
        }
    }
}
