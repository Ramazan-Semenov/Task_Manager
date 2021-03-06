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

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для ChiefViewCRUDTask.xaml
    /// </summary>
    public partial class ChiefViewCRUDTask : Window
    {
        public ChiefViewCRUDTask()
        {
            InitializeComponent();
            DataContext = new ViewModel.ChiefViewModel.ChiefViewModelCRUDTask( Model.Enums.CRUD.Create, null);
        }
    }
}
