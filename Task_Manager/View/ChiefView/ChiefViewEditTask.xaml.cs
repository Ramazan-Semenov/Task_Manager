using System.Windows;

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для ChiefViewEditTask.xaml
    /// </summary>
    public partial class ChiefViewEditTask : Window
    {
        public ChiefViewEditTask()
        {
            InitializeComponent();
        }
        public ChiefViewEditTask(Model.task_book task_Book)
        {
            InitializeComponent();
            DataContext = new ViewModel.ChiefViewModel.ChiefViewModelEditTask(task_Book);
        }
    }
}
