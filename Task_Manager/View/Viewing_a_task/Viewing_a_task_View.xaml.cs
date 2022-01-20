using System.Windows;

namespace Task_Manager.View.Viewing_a_task
{
    /// <summary>
    /// Логика взаимодействия для Viewing_a_task_View.xaml
    /// </summary>
    public partial class Viewing_a_task_View : Window
    {
        public Viewing_a_task_View()
        {
            InitializeComponent();
        }
        public Viewing_a_task_View(Model.task_book task_Book)
        {
            InitializeComponent();
            DataContext = new ViewModel.Viewing_a_task.Viewing_a_task_ViewModel(task_Book);
        }
    }
}
