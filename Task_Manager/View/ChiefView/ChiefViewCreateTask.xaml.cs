using System.Windows;

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для ChiefViewCreateTask.xaml
    /// </summary>
    public partial class ChiefViewCreateTask : Window
    {
        public ChiefViewCreateTask()
        {
            InitializeComponent();
            DataContext = new ViewModel.ChiefViewModel.ChiefViewModelCreateTask();
        }
        public ChiefViewCreateTask(Model.task_book task_Book)
        {
            InitializeComponent();
            DataContext = new ViewModel.ChiefViewModel.ChiefViewModelCreateTask(task_Book);
        }
    }
}
