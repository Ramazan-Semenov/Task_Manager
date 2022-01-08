using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager.ViewModel.StaffViewModel
{
  public  class StaffViewModelCreateTask
    {
        public DateTime DateNow { get; set; } = DateTime.Now;
        public string User { get; set; } = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string desctription { get; set; }
        public Model.task_book Task_Book { get; set; }
        public string name_of_the_task { get; set; }

        public string dep { get; set; } = "Развитие отчетности и разработки инстрементов";
        public List<string> listdep { get; set; } = new List<string>()
        { "Прогнозирование", "Развитие отчетности и разработки инстрементов","Аналитика" };
        public StaffViewModelCreateTask()
        {
            Task_Book = new Model.task_book();
            Create = new RelayCommand(create);
            Openfloderfile = new RelayCommand(openfloderfile);
        }

        public StaffViewModelCreateTask(Model.task_book __task_Book)
        {
            if (__task_Book == null)
            {
                __task_Book = new Model.task_book();
            }
            __task_Book.status = string.Empty;
              Task_Book = new Model.task_book();
            Task_Book = __task_Book;
            Create = new RelayCommand(create);
            Openfloderfile = new RelayCommand(openfloderfile);
        }

        public RelayCommand Create { get; set; }
        void create()
        {
            Task_Book.from_whom = User;
            Task_Book.start_date = DateNow;
            Task_Book.Date_of_compilation = DateTime.Now;

            new Model.CrudOperations.CrudOperations().Create(Task_Book);
            MessageBox.Show("Запись добавлена");
        }
        public RelayCommand Openfloderfile { get; set; }
        void openfloderfile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                MessageBox.Show(openFile.SafeFileName);
            }
        }

    }
}
