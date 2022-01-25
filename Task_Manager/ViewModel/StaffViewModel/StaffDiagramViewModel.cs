using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.ViewModel.StaffViewModel
{
    class StaffDiagramViewModel : ViewModelBase

    {
        public string Dep { get; set; } = Model.Users.Department;
        public string NameStaff { get; set; } = Model.Users.Name;
        public StaffDiagramViewModel()
        {
            B = new List<Model.task_book>(Model.ListElement.ListElement.Task_Books.Where(x => x.Department == Model.Users.Department));
            ListStaff = B.Where(x => x.executor == Model.Users.Name).Select(x => x.executor).ToList();

        }

        public List<Model.task_book> B { get; set; } = new List<Model.task_book>();


        public List<string> ListStaff { get; set; } = new List<string>();


    }
}
