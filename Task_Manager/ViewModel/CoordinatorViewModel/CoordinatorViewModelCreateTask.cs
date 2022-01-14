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

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
   public class CoordinatorViewModelCreateTask : ViewModelBase
    {
        public DateTime DateNow { get; set; } = DateTime.Now;
        public string User { get; set; } = Model.Users.Name;
        //public string desctription { get; set; }
        public Model.task_book Task_Book { get; set; }
        public string name_of_the_task { get; set; }

        private string filename;
        public string FileName { get => filename; set => filename = value; }
        public List<string> liststatus { get { return new List<string> { "принят", "в работе", "завершен" }; } }



        public List<string> ListDepartment
        {
            get
            {

                return new List<string> { "Прогнозирование продаж ФРОВ",
                    "Развитие отчетности и разработки инстрементов", "Аналитика","Взаимодействие КМ",
                "Регулярная отчетность",
                "Бюджетирование"};
            }
        }
        public List<string> Listname_of_the_task
        {
            get
            {

                return new List<string>();
            }
        }
        public List<string> ListStaff
        {
            get
            {

                return new List<string>();
            }
        }

        public CoordinatorViewModelCreateTask()
        {
            Task_Book = new Model.task_book();
            Create = new RelayCommand(create);
            Openfloderfile = new RelayCommand(openfloderfile);
        }

        public CoordinatorViewModelCreateTask(Model.task_book __task_Book)
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
            Task_Book.FilePath =""+ FileName;
            new Model.CrudOperations.CrudOperations().Create(Task_Book);
            //n.chiefLinkPage_.tasks =  new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList());
            //ChiefLinkPage_CreateTask.Ref();
            MessageBox.Show("Запись добавлена");
        }
        public RelayCommand Openfloderfile { get; set; }
        /// <summary>
        /// Реализовать более элегантрую версию
        /// </summary>
        /// 
        void openfloderfile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                string path = openFile.FileName;
                //string pathctreatefile = @"C:\Users\lenovo\Desktop";
                //string subpath = @"Test1234";
                DirectoryInfo dirInfo = new DirectoryInfo(Model.SettingPath.DefaultFilePath);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                //dirInfo.CreateSubdirectory(subpath);
                //string fullName = dirInfo.CreateSubdirectory(subpath).FullName;
                //string newPath = $@"{dirInfo.CreateSubdirectory(subpath).FullName}\{openFile.SafeFileName}";
                string newPath = Model.SettingPath.DefaultFilePath + "\\" + openFile.SafeFileName;
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);

                }

                filename = openFile.SafeFileName;


                RaisePropertyChanged("FileName");
            }


            //MessageBox.Show(openFile.SafeFileName);
        }
    }
}
