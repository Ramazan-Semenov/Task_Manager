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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_Manager.View.StaffView
{
    /// <summary>
    /// Логика взаимодействия для StaffViewPage.xaml
    /// </summary>
    public partial class StaffViewPage : Page
    {
        public StaffViewPage()
        {
            InitializeComponent();
           // DataContext = ViewModel.StaffViewModel.LinkPage_CreateTask.modelPage;

            DataContext = new ViewModel.StaffViewModel.StaffViewModelPage();
        }
    }
}
