using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
  public  class CoordinatorViewModelListTask
    {
        static CoordinatorViewModelListTask()
        {
            CreateTask = new RelayCommand(_CreateTask);
            Create_based_on = new RelayCommand<task_book>(_Create_based_on);
            EditTask = new RelayCommand<task_book>(_EditTask);
            Selected = new RelayCommand<task_book>(_Selected);

        }
        public static RelayCommand CreateTask
        {
            get; set;
        }
        static void _CreateTask()
        {
            View.Coordinator.CoordinatorViewCreateTask ChiefViewCreateTask = new View.Coordinator.CoordinatorViewCreateTask();
            ChiefViewCreateTask.ShowDialog();
        }
        public static RelayCommand<task_book> Create_based_on
        {
            get; set;
        }
        static void _Create_based_on(task_book task)
        {
            View.Coordinator.CoordinatorViewCreateTask ChiefViewCreateTask = new View.Coordinator.CoordinatorViewCreateTask(task);
            ChiefViewCreateTask.ShowDialog();

        }

        public static RelayCommand<task_book> EditTask { get; set; }
        static void _EditTask(task_book task)
        {
            View.Coordinator.CoordinatorViewEditTask staffViewEditTask = new View.Coordinator.CoordinatorViewEditTask(task);
            staffViewEditTask.ShowDialog();
        }
        public static RelayCommand<task_book> Selected { get; set; }
        static void _Selected(task_book task)
        {
            View.Viewing_a_task.Viewing_a_task_View viewing_A_Task_View = new View.Viewing_a_task.Viewing_a_task_View(task);
            viewing_A_Task_View.ShowDialog();
        }

    }
}
