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
