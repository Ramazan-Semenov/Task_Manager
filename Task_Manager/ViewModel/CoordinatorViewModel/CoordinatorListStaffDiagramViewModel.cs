using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
   public class CoordinatorListStaffDiagramViewModel:ViewModelBase

    {
      public  CoordinatorListStaffDiagramViewModel()
        {
 
            ListStaff = B.Select(x => x.executor).Where(x=>x!=null).ToList();
        }

        public List<Model.task_book> B { get; set; } = new List<Model.task_book>();


        public List<string> ListStaff { get; set; } = new List<string>();

        public RelayCommand<string> click { get { return new RelayCommand<string>((string h) => 
        {
            B = new List<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x=>x.Department==h));
            ListStaff = B.GroupBy(x=>x.executor).Select(x=>x.Key).Where(x => x != null).ToList();
            RaisePropertyChanged("ListStaff");
            RaisePropertyChanged("B");
        
        }); ; } }

      public string SelectedItem { get {
                B = new List<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.executor == selectedItem)); 
                
                
                RaisePropertyChanged("B"); ; return selectedItem; } set { selectedItem = value; RaisePropertyChanged("SelectedItem"); } }
      private string selectedItem;
   


    }
}
