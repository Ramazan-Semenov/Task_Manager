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
using System.Windows;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
  public  class CoordinatorViewModelEditTask:ViewModelBase
    {
        private Model.task_book _task_Book;
        public Model.task_book task_Book { get => _task_Book; set => _task_Book = value; }
        public List<string> liststatus { get; set; } = Model.ListElement.ListElement.List_Status;
        public CoordinatorViewModelEditTask(Model.task_book task_Book)
        {
            if (task_Book != null)
            {
                _task_Book = task_Book;

                list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

            }
            else
            {
                MessageBox.Show("Задача не выбрана");
            }
        }
     private    string state { get; set; }
        public CoordinatorViewModelEditTask(Model.task_book task_Book, string state)
        {
            if (task_Book != null)
            {
                _task_Book = task_Book;
                this.state = state;

                list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

            }
            else
            {
                MessageBox.Show("Задача не выбрана");
            }
        }


        public ObservableCollection<Model.task_book> list_of_stages { get; set; }


        public List<string> ListDepartment { get; set; } = Model.ListElement.ListElement.ListDepartment;

        public string selectedDepartment { get; set; }

        public string SelectedDepartment
        {
            get
            {

                Task.Run(AsyncSelectListStaffTask);


                return selectedDepartment;
            }
            set => selectedDepartment = value;
        }

        private async Task AsyncSelectListStaffTask()
        {
            ListStaff=null;
            Listname_of_the_task=null;
            ListStaff = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.executor).Select(x => x.Key).ToList();
            Listname_of_the_task = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.name_of_the_task).Select(x => x.Key).ToList();
            RaisePropertyChanged("ListStaff");
            RaisePropertyChanged("Listname_of_the_task");
        }

        public List<string> Listname_of_the_task
        {
            get; set;
        }
        public List<string> ListStaff
        {
            get; set;

        }


        public RelayCommand Save
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new Model.CrudOperations.CrudOperations().Update(task_Book);
                    MessageBox.Show("");
                });
            }
        }
        public RelayCommand<Model.task_book> delete_a_stage_command
        {
            get
            {
                return new RelayCommand<Model.task_book>((Model.task_book task_Book) =>
                {
                    new Model.CrudOperations.CrudOperations().Delete(task_Book);
                });
            }
        }
        public RelayCommand<Model.task_book> add_a_stage_command
        {
            get
            {
                return new RelayCommand<Model.task_book>((Model.task_book task_Book) =>
                {
                    View.ChiefView.ChiefViewCreateTask chiefViewCreateTask = new View.ChiefView.ChiefViewCreateTask(this.task_Book);
                    chiefViewCreateTask.ShowDialog();
                    list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

                    RaisePropertyChanged("list_of_stages");

                });
            }
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
            if (openFile.ShowDialog() == true)
            {
                string path = openFile.FileName;
                string pathctreatefile = @"C:\Users\lenovo\Desktop";
                string subpath = @"Test1234";
                DirectoryInfo dirInfo = new DirectoryInfo(pathctreatefile);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory(subpath);
                string fullName = dirInfo.CreateSubdirectory(subpath).FullName;
                string newPath = $@"{dirInfo.CreateSubdirectory(subpath).FullName}\{openFile.SafeFileName}";
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);

                }

                //   filename = openFile.SafeFileName;

                _task_Book.FilePath = openFile.SafeFileName;
                RaisePropertyChanged("task_Book");
            }


            //MessageBox.Show(openFile.SafeFileName);
        }

    }
}
