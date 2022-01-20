using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Task_Manager.Model;

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorViewListTask.xaml
    /// </summary>
    public partial class CoordinatorViewListTask : UserControl
    {
        public static readonly DependencyProperty Task_BookProperty = DependencyProperty.Register(
        nameof(Task_Book), typeof(IList<task_book>), typeof(CoordinatorViewListTask), new FrameworkPropertyMetadata(null,
           FrameworkPropertyMetadataOptions.None));

        public IList<task_book> Task_Book
        {
            get { return (IList<task_book>)GetValue(Task_BookProperty); }
            set { SetValue(Task_BookProperty, value); }
        }
        public CoordinatorViewListTask()
        {
            InitializeComponent();
        }

        private void FilterDataGrid_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void FilterDataGrid_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void FilterDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
