using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Task_Manager.Model;

namespace Task_Manager.View.StaffView
{
    /// <summary>
    /// Логика взаимодействия для StaffViewListTask.xaml
    /// </summary>
    public partial class StaffViewListTask : UserControl
    {
        public static readonly DependencyProperty Task_BookProperty = DependencyProperty.Register(
          nameof(Task_Book), typeof(IList<task_book>), typeof(StaffViewListTask), new FrameworkPropertyMetadata(new List<task_book>(),
             FrameworkPropertyMetadataOptions.None));

        public IList<task_book> Task_Book
        {
            get { return (IList<task_book>)GetValue(Task_BookProperty); }
            set { SetValue(Task_BookProperty, value); }
        }
        public StaffViewListTask()
        {
            InitializeComponent();
            //Task_Book = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList());
            //DataContext = new ViewModel.StaffViewModel.StaffViewModelListTask();
        }

        private void FilterDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
