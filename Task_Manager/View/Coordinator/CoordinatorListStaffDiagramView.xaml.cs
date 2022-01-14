using GalaSoft.MvvmLight.Command;
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

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorListStaffDiagramView.xaml
    /// </summary>
    public partial class CoordinatorListStaffDiagramView : Page
    {
        public CoordinatorListStaffDiagramView()
        {
            InitializeComponent();
           DataContext = new ViewModel.CoordinatorViewModel.CoordinatorListStaffDiagramViewModel() ;
        }

       
    }
}
