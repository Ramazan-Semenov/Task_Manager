﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager.ViewModel.StaffViewModel
{
   public class StaffViewModelEdit
    {
        private Model.task_book _task_Book;
         public Model.task_book task_Book { get=>_task_Book; set=>_task_Book=value; }
        public StaffViewModelEdit( Model.task_book task_Book)
        {
            if (task_Book!=null)
            {
                _task_Book = task_Book;

                list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

            }
            else
            {
                MessageBox.Show("Задача не выбрана");
            }
        }


     public ObservableCollection<Model.task_book> list_of_stages { get; set; }

    }
}
