using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            MessageBox.Show(task_Book.executor);
            DataContext = new ViewModel.StaffViewModel.StaffViewModelEdit(task_Book);
        }
     
    }
}
