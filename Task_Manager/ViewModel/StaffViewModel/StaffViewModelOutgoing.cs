using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.StaffViewModel
{
    internal class StaffViewModelOutgoing : ViewModelBase
    {
        public static ObservableCollection<task_book> Task_Book { get; set; }
        static StaffViewModelOutgoing()
        {
            Task_Book = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x=>x.from_whom==Model.Users.Name).AsParallel<task_book>());
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
        public static RelayCommand<task_book> Selected { get; set; }
        static void _Selected(task_book task)
        {
            View.Viewing_a_task.Viewing_a_task_View viewing_A_Task_View = new View.Viewing_a_task.Viewing_a_task_View(task);
            viewing_A_Task_View.ShowDialog();
        }
    }
}