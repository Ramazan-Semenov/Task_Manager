using System.Windows;

namespace Task_Manager.View.StaffView
{
    /// <summary>
    /// Логика взаимодействия для StaffViewEditTask.xaml
    /// </summary>
    public partial class StaffViewEditTask : Window
    {
        public StaffViewEditTask(Model.task_book task_Book)
        {
            InitializeComponent();
            DataContext = new ViewModel.StaffViewModel.StaffViewModelEdit(task_Book);
        }

    }
}
