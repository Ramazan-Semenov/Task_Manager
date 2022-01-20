using System.Windows;

namespace Task_Manager.View.StaffView
{
    /// <summary>
    /// Логика взаимодействия для StaffViewCreateTask.xaml
    /// </summary>
    public partial class StaffViewCreateTask : Window
    {
        public StaffViewCreateTask()
        {
            InitializeComponent();
            DataContext = new ViewModel.StaffViewModel.StaffViewModelCreateTask();
        }
        public StaffViewCreateTask(Model.task_book task_)
        {
            InitializeComponent();
            DataContext = new ViewModel.StaffViewModel.StaffViewModelCreateTask(task_);
        }
    }
}
