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
