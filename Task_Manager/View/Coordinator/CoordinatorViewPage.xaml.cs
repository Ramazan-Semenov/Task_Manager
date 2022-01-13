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
using FilterDataGrid;

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorViewPage.xaml
    /// </summary>
    public partial class CoordinatorViewPage : Page
    {
       
        public CoordinatorViewPage(string department)
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorViewModelPage(department);
          
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs  e)
        {
            MessageBox.Show("Ok");
        }
    }
}
