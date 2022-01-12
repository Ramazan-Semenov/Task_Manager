using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.ChiefViewModel
{
  public  class ChiefViewModelListTask
    {
        static ChiefViewModelListTask()
        {
            CreateTask = new RelayCommand(_CreateTask);
            Create_based_on = new RelayCommand<task_book>(_Create_based_on);
            EditTask = new RelayCommand<task_book>(_EditTask);

        }
        public static RelayCommand CreateTask
        {
            get; set;
        }
        static void _CreateTask()
        {
            View.ChiefView.ChiefViewCreateTask ChiefViewCreateTask = new View.ChiefView.ChiefViewCreateTask();
            ChiefViewCreateTask.ShowDialog();
        }
        public static RelayCommand<task_book> Create_based_on
        {
            get; set;
        }
        static void _Create_based_on(task_book task)
        {
            View.ChiefView.ChiefViewCreateTask ChiefViewCreateTask = new View.ChiefView.ChiefViewCreateTask(task);
            ChiefViewCreateTask.ShowDialog();

            //MessageBox.Show(task.Number.ToString());
        }

        public static RelayCommand<task_book> EditTask { get; set; }
        static void _EditTask(task_book task)
        {
            View.ChiefView.ChiefViewEditTask staffViewEditTask = new View.ChiefView.ChiefViewEditTask(task);
            staffViewEditTask.ShowDialog();
        }

    }
}
