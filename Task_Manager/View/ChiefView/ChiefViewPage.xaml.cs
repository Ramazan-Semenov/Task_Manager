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

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для ChiefViewPage.xaml
    /// </summary>
    public partial class ChiefViewPage : Page
    {
        //public ChiefViewPage()
        //{
        //    InitializeComponent();
        //    //DataContext = Control.modelPage;
        //    //DataContext = new ViewModel.ChiefViewModel.ChiefViewModelPage();
        //    //DataContext = ViewModel.ChiefViewModel.ChiefLinkPage_CreateTask.ChiefViewModelPage;

        //}
        public ChiefViewPage(/*IEnumerable<Model.task_book> tasks,*/ string Depatment)
        {
            InitializeComponent();

            //ViewModel.ChiefViewModel.ChiefLinkPage_CreateTask.Dep = Depatment;
            //ViewModel.ChiefViewModel.ChiefLinkPage_CreateTask.ChiefViewModelPage.Department = Depatment;
            //DataContext =   ViewModel.ChiefViewModel.ChiefLinkPage_CreateTask.ChiefViewModelPage;
            DataContext = new ViewModel.ChiefViewModel.ChiefViewModelPage(/*tasks,*/ Depatment);
        }
    }
}
