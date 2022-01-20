using System.Windows.Controls;

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
