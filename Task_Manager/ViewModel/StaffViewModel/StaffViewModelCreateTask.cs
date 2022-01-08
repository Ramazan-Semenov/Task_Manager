using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager.ViewModel.StaffViewModel
{
  public  class StaffViewModelCreateTask:ViewModelBase
    {
        public DateTime DateNow { get; set; } = DateTime.Now;
        public string User { get; set; } = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string desctription { get; set; }
        public Model.task_book Task_Book { get; set; }
        public string name_of_the_task { get; set; }

        private string filename;
        public string FileName { get=>filename; set=>filename=value; }
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
        /// <summary>
        /// Реализовать более элегантрую версию
        /// </summary>
        void openfloderfile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string path = openFile.FileName;
            string pathctreatefile = @"C:\Users\lenovo\Desktop";
            string subpath = @"Test1234";
            DirectoryInfo dirInfo = new DirectoryInfo(pathctreatefile);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            MessageBox.Show(dirInfo.CreateSubdirectory(subpath).FullName);
            string newPath = $@"{dirInfo.CreateSubdirectory(subpath).FullName}\{openFile.SafeFileName}";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                // альтернатива с помощью класса File
                // File.Copy(path, newPath, true);
            }
            //if (openFile.ShowDialog() == true)
            //{
            filename = openFile.SafeFileName;


            RaisePropertyChanged("FileName");

            //MessageBox.Show(openFile.SafeFileName);
        }
    }

    
}
