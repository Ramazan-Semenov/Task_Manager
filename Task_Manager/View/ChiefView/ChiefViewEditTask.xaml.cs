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
using System.Windows.Shapes;

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для ChiefViewEditTask.xaml
    /// </summary>
    public partial class ChiefViewEditTask : Window
    {
        public ChiefViewEditTask()
        {
            InitializeComponent();
        }
        public ChiefViewEditTask(Model.task_book task_Book)
        {
            InitializeComponent();
            DataContext = new ViewModel.ChiefViewModel.ChiefViewModelEditTask(task_Book);
        }
    }
}