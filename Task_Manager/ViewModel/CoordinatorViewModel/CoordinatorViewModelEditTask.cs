using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
    public class CoordinatorViewModelEditTask : ViewModelBase
    {
        //private Model.task_book _task_Book;
        //public Model.task_book task_Book { get => _task_Book; set => _task_Book = value; }
        //public List<string> liststatus { get; set; } = Model.ListElement.ListElement.List_Status;
        //public CoordinatorViewModelEditTask(Model.task_book task_Book)
        //{
        //    if (task_Book != null)
        //    {
        //        _task_Book = task_Book;

        //        list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

        //    }
        //    else
        //    {
        //        MessageBox.Show("Задача не выбрана");
        //    }
        //}
        //private string state { get; set; }
        //public CoordinatorViewModelEditTask(Model.task_book task_Book, string state)
        //{
        //    if (task_Book != null)
        //    {
        //        _task_Book = task_Book;
        //        this.state = state;

        //        list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

        //    }
        //    else
        //    {
        //        MessageBox.Show("Задача не выбрана");
        //    }
        //}


        //public ObservableCollection<Model.task_book> list_of_stages { get; set; }


        //public List<string> ListDepartment { get; set; } = Model.ListElement.ListElement.ListDepartment;

        //public string selectedDepartment { get; set; }

        //public string SelectedDepartment
        //{
        //    get
        //    {

        //        Task.Run(AsyncSelectListStaffTask);


        //        return selectedDepartment;
        //    }
        //    set => selectedDepartment = value;
        //}

        //private async Task AsyncSelectListStaffTask()
        //{
        //    ListStaff = null;
        //    Listname_of_the_task = null;
        //    ListStaff = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.executor).Select(x => x.Key).ToList();
        //    Listname_of_the_task = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.name_of_the_task).Select(x => x.Key).ToList();
        //    RaisePropertyChanged("ListStaff");
        //    RaisePropertyChanged("Listname_of_the_task");
        //}

        //public List<string> Listname_of_the_task
        //{
        //    get; set;
        //}
        //public List<string> ListStaff
        //{
        //    get; set;

        //}


        //public RelayCommand Save
        //{
        //    get
        //    {
        //        return new RelayCommand(() =>
        //        {
        //            new Model.CrudOperations.CrudOperations().Update(task_Book);
        //            MessageBox.Show("");
        //        });
        //    }
        //}
        //public RelayCommand<Model.task_book> delete_a_stage_command
        //{
        //    get
        //    {
        //        return new RelayCommand<Model.task_book>((Model.task_book task_Book) =>
        //        {
        //            new Model.CrudOperations.CrudOperations().Delete(task_Book);
        //        });
        //    }
        //}
        //public RelayCommand<Model.task_book> add_a_stage_command
        //{
        //    get
        //    {
        //        return new RelayCommand<Model.task_book>((Model.task_book task_Book) =>
        //        {
        //            View.ChiefView.ChiefViewCreateTask chiefViewCreateTask = new View.ChiefView.ChiefViewCreateTask(this.task_Book);
        //            chiefViewCreateTask.ShowDialog();
        //            list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

        //            RaisePropertyChanged("list_of_stages");

        //        });
        //    }
        //}
        //public RelayCommand Openfloderfile
        //{
        //    get
        //    {

        //        return new RelayCommand(openfloderfile);
        //    }
        //}
        //void openfloderfile()
        //{
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    if (openFile.ShowDialog() == true)
        //    {
        //        string path = openFile.FileName;
        //        string pathctreatefile = @"C:\Users\lenovo\Desktop";
        //        string subpath = @"Test1234";
        //        DirectoryInfo dirInfo = new DirectoryInfo(pathctreatefile);
        //        if (!dirInfo.Exists)
        //        {
        //            dirInfo.Create();
        //        }
        //        dirInfo.CreateSubdirectory(subpath);
        //        string fullName = dirInfo.CreateSubdirectory(subpath).FullName;
        //        string newPath = $@"{dirInfo.CreateSubdirectory(subpath).FullName}\{openFile.SafeFileName}";
        //        FileInfo fileInf = new FileInfo(path);
        //        if (fileInf.Exists)
        //        {
        //            fileInf.CopyTo(newPath, true);

        //        }

        //        //   filename = openFile.SafeFileName;

        //        _task_Book.FilePath = openFile.SafeFileName;
        //        RaisePropertyChanged("task_Book");
        //    }


        //    //MessageBox.Show(openFile.SafeFileName);
        //}
        private Model.task_book _task_Book;
        private static string Department;
        public Model.task_book task_Book { get => _task_Book; set => _task_Book = value; }
        public List<string> liststatus = Model.ListElement.ListElement.List_Status;
        public List<string> List_task_type { get; set; } = Model.ListElement.ListElement.List_type_task;
        public List<View.ChiefView.tecon> implicit_request_template { get; set; } = new List<View.ChiefView.tecon>();
        public List<string> Listname_of_the_task
        {
            get; set;
        } = Model.ListElement.ListElement.name_task_by_department(Department);
        public List<string> ListStaff
        {
            get; set;

        } = Model.ListElement.ListElement.staff_by_department(Department);
        public List<string> ListDepartment
        { 
            get; set; 
        } = Model.ListElement.ListElement.ListDepartment;

        private string selectedDepartment;

        public string SelectedDepartment
        {
            get
            {
                   RaisePropertyChanged("implicit_request_template");
                RaisePropertyChanged("list_implicit_request");
                Task.Run(AsyncSelectListStaffTask);


                return selectedDepartment;
            }
            set => selectedDepartment = value;
        }

        private async Task AsyncSelectListStaffTask()
        {
            ListStaff = null;
            Listname_of_the_task = null;
            ListStaff = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.executor).Select(x => x.Key).ToList();
            Listname_of_the_task = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.name_of_the_task).Select(x => x.Key).ToList();
            RaisePropertyChanged("ListStaff");
            RaisePropertyChanged("Listname_of_the_task");
            RaisePropertyChanged(" list_implicit_request");
        }
        public CoordinatorViewModelEditTask(Model.task_book task_Book)
        {
            if (task_Book != null)
            {
                _task_Book = task_Book;
                Department = task_Book.Department;
                list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.name_of_the_task == _task_Book.name_of_the_task) & (x.Department == _task_Book.Department)));
                if (task_Book.implicit_request != null)
                {
                    List<View.ChiefView.gridelement> lis = JsonConvert.DeserializeObject<List<View.ChiefView.gridelement>>(task_Book.implicit_request); ;
                    List<View.ChiefView.tecon> tecons = new List<View.ChiefView.tecon>();
                    if (lis != null)
                    {


                        foreach (var item in lis)
                        {
                            tecons.Add(new View.ChiefView.tecon { Content = item.userelement1.Content.ToString(), Text = item.userelement2.Content.ToString() });
                        }
                        implicit_request_template = tecons;
                        //  RaisePropertyChanged("implicit_request_template");
                    }
                }
            }
            else
            {
                MessageBox.Show("Задача не выбрана");
            }
        }


        public ObservableCollection<Model.task_book> list_of_stages { get; set; }




        public RelayCommand Save
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new Model.CrudOperations.CrudOperations().Update(task_Book);
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
                    View.StaffView.StaffViewCreateTask chiefViewCreateTask = new View.StaffView.StaffViewCreateTask(this.task_Book);
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

                DirectoryInfo dirInfo = new DirectoryInfo(Model.SettingPath.DefaultFilePath);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                string newPath = Model.SettingPath.DefaultFilePath + "\\" + openFile.SafeFileName;
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);

                }

                _task_Book.FilePath = openFile.SafeFileName;


                RaisePropertyChanged("task_Book");
            }



            //MessageBox.Show(openFile.SafeFileName);
        }

    }
}
