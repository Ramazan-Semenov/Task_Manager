using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.ViewModel.StaffViewModel
{
   public class StaffViewModelEdit
    {
        private Model.task_book _task_Book;
         public Model.task_book task_Book { get=>_task_Book; set=>_task_Book=value; }
        public StaffViewModelEdit( Model.task_book task_Book)
        {
           _task_Book = task_Book;
        }
    }
}
