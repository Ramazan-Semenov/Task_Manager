﻿using System;
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