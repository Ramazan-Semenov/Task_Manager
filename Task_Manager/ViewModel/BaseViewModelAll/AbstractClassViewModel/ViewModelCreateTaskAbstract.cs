using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows;

namespace Task_Manager.ViewModel.BaseViewModelAll.AbstractClassViewModel
{
    public abstract class ViewModelCreateTaskAbstract : ViewModelBase
    {
        protected static Model.CrudOperations.list_implicit_request implicit_Request = new Model.CrudOperations.list_implicit_request();
        public DateTime DateNow { get; set; } = DateTime.Now;
        public abstract string User { get; set; }
        public abstract Model.task_book Task_Book { get; set; }
        public abstract string name_of_the_task { get; set; }
        public abstract Visibility list_implicit_requestVisibility { get; set; }
        public abstract Visibility implicit_request_templateVisibility { get; set; }

        public abstract List<string> List_task_type { get; set; }
        public abstract string implicit_requestItem { get; set; }

        public abstract string SelectedDepartment { get; set; }
        public abstract bool IsChecked { get; set; }
        public abstract string FileName { get; set; }
        public abstract List<string> liststatus { get; set; }
        public abstract List<string> list_implicit_request { get; set; }
        public abstract List<View.ChiefView.tecon> implicit_request_template { get; set; }
        public virtual List<string> ListDepartment { get; set; }
        public abstract List<string> Listname_of_the_task { get; set; }
        public abstract List<string> ListStaff { get; set; }
        public abstract RelayCommand Create { get; set; }
        public abstract RelayCommand Openfloderfile { get; set; }
    }
      
    
}
