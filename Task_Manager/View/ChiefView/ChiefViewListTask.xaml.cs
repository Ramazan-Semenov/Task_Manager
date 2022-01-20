using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Task_Manager.Model;

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для ChiefViewListTask.xaml
    /// </summary>
    public partial class ChiefViewListTask : UserControl
    {
        public static readonly DependencyProperty Task_BooksProperty = DependencyProperty.Register(
         nameof(Task_Book), typeof(IList<task_book>), typeof(ChiefViewListTask), new FrameworkPropertyMetadata(null,
            FrameworkPropertyMetadataOptions.None));

        public IList<task_book> Task_Book
        {
            get { return (IList<task_book>)GetValue(Task_BooksProperty); }
            set { SetValue(Task_BooksProperty, value); }
        }
        public ChiefViewListTask()
        {
            InitializeComponent();
        }

        private void FilterDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
    }
}
