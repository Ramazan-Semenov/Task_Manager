using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task_Manager.Model;
using Task_Manager.View.ChiefView;
using Task_Manager.ViewModel.BaseViewModelAll.AbstractClassViewModel;

namespace Task_Manager.ViewModel.BaseViewModelAll
{
    public class ViewModelCreateTaskBase : ViewModelCreateTaskAbstract, IDisposable
    {
        protected List<string> _Listname_of_the_task = new List<string>();
        public override List<string> Listname_of_the_task { get => _Listname_of_the_task; set => _Listname_of_the_task=value; }
        protected List<string> _ListStaff = new List<string>();
        public override List<string> ListStaff { get => _ListStaff; set => _ListStaff=value; }
        public override RelayCommand Create { get { return new RelayCommand(()=>
        {
            Task.Run(()=> 
            {
                List<View.ChiefView.gridelement> b = new List<View.ChiefView.gridelement>();

                foreach (var item in implicit_request_template)
                {
                    b.Add(new View.ChiefView.gridelement { userelement1 = new View.ChiefView.userelement { Content = item.Content }, userelement2 = new View.ChiefView.userelement { Content = item.Text } });
                }

                Task_Book.implicit_request = JsonConvert.SerializeObject(b);
                Task_Book.from_whom = User;
                Task_Book.start_date = DateNow;
                Task_Book.status = string.Empty;
                Task_Book.Date_of_compilation = DateTime.Now;
                Task_Book.FilePath = "" + FileName;
                new Model.CrudOperations.CrudOperations().Create(Task_Book);
                MessageBox.Show("Запись добавлена");

            });
        
        }); } set => throw new NotImplementedException(); }
        public override RelayCommand Openfloderfile { get { return new RelayCommand(()=> 
        {
            Task.Run(()=> 
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

                    _FileName = openFile.SafeFileName;


                    RaisePropertyChanged("FileName");
                }

            });
        
        }); } set => throw new NotImplementedException(); }
        protected string selectedDepartment;
        public override string SelectedDepartment  
        {
            get
            {
                implicit_Request = new Model.CrudOperations.list_implicit_request();
                implicit_request_template = new List<View.ChiefView.tecon>();
                list_implicit_request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == selectedDepartment).Select(x => x.name).ToList();
                RaisePropertyChanged("implicit_request_template");
                RaisePropertyChanged("list_implicit_request");
                Task.Run(AsyncSelectListStaffTask);


             return selectedDepartment;
            }
            set => selectedDepartment = value;
        }
        protected async Task AsyncSelectListStaffTask()
        {
            ListStaff = null;
            Listname_of_the_task = null;
            list_implicit_request = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).Select(x => x.implicit_request).ToList();
            ListStaff = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.executor).Select(x => x.Key).ToList();
            Listname_of_the_task = Model.ListElement.ListElement.Task_Books.Where(x => x.Department == selectedDepartment).GroupBy(x => x.name_of_the_task).Select(x => x.Key).ToList();
            RaisePropertyChanged("ListStaff");
            RaisePropertyChanged("Listname_of_the_task");
            RaisePropertyChanged(" list_implicit_request");
        }
        protected bool _IsChecked;
        public override bool IsChecked
        {
            get
            {

                if (_IsChecked == false)
                {
                    implicit_Request = new Model.CrudOperations.list_implicit_request();

                    list_implicit_requestVisibility = Visibility.Collapsed;
                    implicit_request_templateVisibility = Visibility.Collapsed;
                }
                else
                {
                    list_implicit_requestVisibility = Visibility.Visible;
                    implicit_request_templateVisibility = Visibility.Visible;
                }
                RaisePropertyChanged("list_implicit_requestVisibility");
                RaisePropertyChanged("implicit_request_templateVisibility");
                return _IsChecked;
            }
            set
            {
                _IsChecked = value;
            }
        }
        protected string _FileName;
        public override string FileName { get => _FileName; set => _FileName=value; }
        public override List<string> liststatus { get; set; }= Model.ListElement.ListElement.List_Status;
        public override List<string> list_implicit_request { get; set ; }
        public override List<tecon> implicit_request_template { get; set; } = new List<tecon>();
        public override List<string> ListDepartment { get; set; } = Model.ListElement.ListElement.ListDepartment;
        public override task_book Task_Book { get;set; }
        public override string name_of_the_task { get; set; }
        public override Visibility list_implicit_requestVisibility { get; set; } = Visibility.Collapsed;
        public override Visibility implicit_request_templateVisibility { get; set; } = Visibility.Collapsed;
        public override List<string> List_task_type { get; set; } = Model.ListElement.ListElement.List_type_task;

        protected string _privatr_implicit_requestItem;
        private bool disposedValue;

        public override string implicit_requestItem
        {
            get
            {
                Task.Run(()=> {
                    if (_privatr_implicit_requestItem != null)
                    {
                        implicit_Request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => (x.name == _privatr_implicit_requestItem) & (x.department == Task_Book.Department)).FirstOrDefault();

                        List<View.ChiefView.gridelement> lis = JsonConvert.DeserializeObject<List<View.ChiefView.gridelement>>(implicit_Request.implicit_request_json); ;
                        List<View.ChiefView.tecon> tecons = new List<View.ChiefView.tecon>();
                        if (lis != null)
                        {


                            foreach (var item in lis)
                            {
                                tecons.Add(new View.ChiefView.tecon { Content = item.userelement1.Content.ToString(), Text = item.userelement2.Content.ToString() });
                            }
                            implicit_request_template = tecons;
                            RaisePropertyChanged("implicit_request_template");
                        }

                    }



                });
                return _privatr_implicit_requestItem;

            }
            set { _privatr_implicit_requestItem = value; }
        }
        public override string User { get; set; } = Model.Users.Name;
        public ViewModelCreateTaskBase()
        {
            Task.Run(()=> 
            {
                Task_Book = new Model.task_book();
                Task_Book.Department = Model.Users.Department;
                Task_Book.end_date = DateNow;
                list_implicit_request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == Model.Users.Department).Select(x => x.name).ToList();


            });
            Task.Run(AsyncSelectListStaffTask);
        }
        public ViewModelCreateTaskBase(Model.task_book __task_Book)
        {
            if (__task_Book == null)
            {
                __task_Book = new Model.task_book();
            }
            __task_Book.status = string.Empty;
            Task_Book = new Model.task_book();
            Task_Book = __task_Book;
            Task.Run(() =>
            {
                
                if (__task_Book.implicit_request != null)
                {
                    List<gridelement> lis = JsonConvert.DeserializeObject<List<View.ChiefView.gridelement>>(__task_Book.implicit_request); ;
                    List<tecon> tecons = new List<View.ChiefView.tecon>();
                    if (lis != null)
                    {

                        list_implicit_request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == Model.Users.Department).Select(x => x.name).ToList();
                        foreach (var item in lis)
                        {
                            tecons.Add(new View.ChiefView.tecon { Content = item.userelement1.Content.ToString(), Text = item.userelement2.Content.ToString() });
                        }
                        implicit_request_template = tecons;
                    }
                    _IsChecked = true;
                }
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~ViewModelCreateTaskBase()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
