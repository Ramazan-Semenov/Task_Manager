using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.ViewModel.Viewing_a_task
{
   public class Viewing_a_task_ViewModel:ViewModelBase
    {
        private Model.task_book _task_Book;
        public Model.task_book task_Book { get => _task_Book; set => _task_Book = value; }
        public ObservableCollection<Model.task_book> list_of_stages { get; set; }

        public Viewing_a_task_ViewModel(Model.task_book task_Book)
        {
            _task_Book = task_Book;
            list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));
        }



        public RelayCommand Openfloderfile
        {
            get
            {

                return new RelayCommand(openfloderfile);
            }
        }
        void openfloderfile()
        {
            OpenFileDialog openFile = new OpenFileDialog();

            string FileNamePath = _task_Book.FilePath;

            if (openFile.ShowDialog() == true)
            {
                //string path = openFile.FileName;
                //string pathctreatefile = @"C:\Users\lenovo\Desktop";
                //string subpath = @"Test1234";
                //DirectoryInfo dirInfo = new DirectoryInfo(pathctreatefile);
                //if (!dirInfo.Exists)
                //{
                //    dirInfo.Create();
                //}
                //dirInfo.CreateSubdirectory(subpath);
                //string fullName = dirInfo.CreateSubdirectory(subpath).FullName;
                //string newPath = $@"{dirInfo.CreateSubdirectory(subpath).FullName}\{openFile.SafeFileName}";
                //FileInfo fileInf = new FileInfo(path);
                //if (fileInf.Exists)
                //{
                //    fileInf.CopyTo(newPath, true);

                //}

                //   filename = openFile.SafeFileName;

                _task_Book.FilePath = openFile.SafeFileName;
                RaisePropertyChanged("task_Book");
            }


            //MessageBox.Show(openFile.SafeFileName);
        }
    }
}
