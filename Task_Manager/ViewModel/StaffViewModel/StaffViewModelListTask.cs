using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.StaffViewModel
{
  public  class StaffViewModelListTask : ViewModelBase
    {
        //private static ObservableCollection<task_book> task_Books;
        //public static ObservableCollection<task_book> Task_Books
        //{
        //    get => task_Books; set
        //    {
        //        task_Books = value; /*OnPropertyChanged(nameof(Task_Books))*/;
        //    }
        //}
      //  public static  task_book Selected { get; set; }

  
        //public StaffViewModelListTask()
        //{
        //    task_Books = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList());
        //}
        static StaffViewModelListTask()
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
            View.StaffView.StaffViewCreateTask staffViewCreateTask = new View.StaffView.StaffViewCreateTask();
            staffViewCreateTask.ShowDialog();
        }
        public static RelayCommand<task_book> Create_based_on
        {
            get; set;
        }
        static void _Create_based_on(task_book task)
        {
            View.StaffView.StaffViewCreateTask staffViewCreateTask = new View.StaffView.StaffViewCreateTask(task);
            staffViewCreateTask.ShowDialog();

            //MessageBox.Show(task.Number.ToString());
        }

        public static RelayCommand<task_book> EditTask { get; set; }
       static void _EditTask(task_book task)
        {
            View.StaffView.StaffViewEditTask staffViewEditTask = new View.StaffView.StaffViewEditTask(task);
            staffViewEditTask.ShowDialog();
        }

    }
}
