using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.StaffViewModel
{
 public static class LinkPage_CreateTask
    {
        public static ViewModel.StaffViewModel.StaffViewModelPage modelPage { get; set; } = new ViewModel.StaffViewModel.StaffViewModelPage();
        public static void Ref()
        {
            LinkPage_CreateTask.modelPage.tasks = new System.Collections.ObjectModel.ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.Department == Users.Department));

        }
    }
}
