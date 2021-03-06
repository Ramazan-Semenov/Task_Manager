using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager.ViewModel.StaffViewModel
{
    public class StaffViewModelCreateTask : ViewModel.BaseViewModelAll.ViewModelCreateTaskBase
    {
        public override RelayCommand Create { get { return new RelayCommand(() => { MessageBox.Show(SelectedDepartment); }); } }

        public StaffViewModelCreateTask()
        { }
        public StaffViewModelCreateTask(Model.task_book task_Book):base(task_Book)
        { }

        //private static Model.CrudOperations.list_implicit_request implicit_Request = new Model.CrudOperations.list_implicit_request();
        //public DateTime DateNow { get; set; } = DateTime.Now;
        //public string User { get; set; } = Model.Users.Name;
        //public Model.task_book Task_Book { get; set; }
        //public string name_of_the_task { get; set; }
        //public Visibility list_implicit_requestVisibility { get; set; } = Visibility.Collapsed;
        //public Visibility implicit_request_templateVisibility { get; set; } = Visibility.Collapsed;

        //public List<string> List_task_type { get; set; } = Model.ListElement.ListElement.List_type_task;


        //private bool _IsChecked;
        //public bool IsChecked
        //{
        //    get
        //    {

        //        if (_IsChecked == false)
        //        {
        //            implicit_Request = new Model.CrudOperations.list_implicit_request();

        //            list_implicit_requestVisibility = Visibility.Collapsed;
        //            implicit_request_templateVisibility = Visibility.Collapsed;
        //        }
        //        else
        //        {
        //            list_implicit_requestVisibility = Visibility.Visible;
        //            implicit_request_templateVisibility = Visibility.Visible;
        //        }
        //        RaisePropertyChanged("list_implicit_requestVisibility");
        //        RaisePropertyChanged("implicit_request_templateVisibility");
        //        return _IsChecked;
        //    }
        //    set
        //    {
        //        _IsChecked = value;
        //    }
        //}


        //private string filename;
        //public string FileName { get => filename; set => filename = value; }
        //public List<string> liststatus = Model.ListElement.ListElement.List_Status;


        //public List<string> list_implicit_request { get; set; } = new List<string>();

        //public List<View.ChiefView.tecon> implicit_request_template { get; set; } = new List<View.ChiefView.tecon>();

        //public List<string> ListDepartment { get; set; } = Model.ListElement.ListElement.ListDepartment;



        //private string _privatr_implicit_requestItem;
        //public string implicit_requestItem
        //{
        //    get
        //    {
        //        if (_privatr_implicit_requestItem != null)
        //        {
        //            implicit_Request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => (x.name == _privatr_implicit_requestItem) & (x.department == Model.Users.Department)).FirstOrDefault();

        //            List<View.ChiefView.gridelement> lis = JsonConvert.DeserializeObject<List<View.ChiefView.gridelement>>(implicit_Request.implicit_request_json); ;
        //            List<View.ChiefView.tecon> tecons = new List<View.ChiefView.tecon>();
        //            if (lis != null)
        //            {


        //                foreach (var item in lis)
        //                {
        //                    tecons.Add(new View.ChiefView.tecon { Content = item.userelement1.Content.ToString(), Text = item.userelement2.Content.ToString() });
        //                }
        //                implicit_request_template = tecons;
        //                RaisePropertyChanged("implicit_request_template");
        //            }

        //        }

        //        return _privatr_implicit_requestItem;
        //    }
        //    set { _privatr_implicit_requestItem = value; }
        //}


        //public List<string> Listname_of_the_task
        //{
        //    get; set;
        //} = Model.ListElement.ListElement.name_task_by_department(Model.Users.Department);
        //public List<string> ListStaff
        //{
        //    get; set;

        //} = Model.ListElement.ListElement.staff_by_department(Model.Users.Department);

        //public StaffViewModelCreateTask()
        //{
        //    Task_Book = new Model.task_book();
        //    Task_Book.Department = Model.Users.Department;
        //    Task_Book.end_date = DateNow;
        //    //Create = new RelayCommand(create);
        //    Openfloderfile = new RelayCommand(openfloderfile);
        //    list_implicit_request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department ==Model.Users.Department).Select(x => x.name).ToList();
   
        //}

        //public StaffViewModelCreateTask(Model.task_book __task_Book)
        //{
        //    if (__task_Book == null)
        //    {
        //        __task_Book = new Model.task_book();
        //    }
        //    __task_Book.status = string.Empty;
        //    Task_Book = new Model.task_book();
        //    Task_Book = __task_Book;
        // //   Create = new RelayCommand(create);
        //    Openfloderfile = new RelayCommand(openfloderfile);
        //    if (__task_Book.implicit_request != null)
        //    {
        //        List<View.ChiefView.gridelement> lis = JsonConvert.DeserializeObject<List<View.ChiefView.gridelement>>(__task_Book.implicit_request); ;
        //        List<View.ChiefView.tecon> tecons = new List<View.ChiefView.tecon>();
        //        if (lis != null)
        //        {

        //            list_implicit_request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == Model.Users.Department).Select(x => x.name).ToList();
        //            foreach (var item in lis)
        //            {
        //                tecons.Add(new View.ChiefView.tecon { Content = item.userelement1.Content.ToString(), Text = item.userelement2.Content.ToString() });
        //            }
        //            implicit_request_template = tecons;
        //        }
        //        _IsChecked = true;
        //    }
        //}

        //public RelayCommand Create { get {

        //        return new RelayCommand(() => { Task.Run(create); });
        //    } }
        //void create()
        //{


        //    List<View.ChiefView.gridelement> b = new List<View.ChiefView.gridelement>();


        //    foreach (var item in implicit_request_template)
        //    {
        //        b.Add(new View.ChiefView.gridelement { userelement1 = new View.ChiefView.userelement { Content= item.Content }, userelement2 = new View.ChiefView.userelement {  Content= item.Text } }) ;
        //    }

        //    Task_Book.implicit_request = JsonConvert.SerializeObject(b);
        //    Task_Book.from_whom = User;
        //    Task_Book.start_date = DateNow;
        //    Task_Book.status = string.Empty;
        //    Task_Book.Date_of_compilation = DateTime.Now;
        //    Task_Book.FilePath = "" + FileName;
        //    new Model.CrudOperations.CrudOperations().Create(Task_Book);
        //    MessageBox.Show("Запись добавлена");
        //}
        //public RelayCommand Openfloderfile { get; set; }
        ///// <summary>
        ///// Реализовать более элегантрую версию
        ///// </summary>
        ///// 
        //void openfloderfile()
        //{
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    if (openFile.ShowDialog() == true)
        //    {
        //        string path = openFile.FileName;

        //        DirectoryInfo dirInfo = new DirectoryInfo(Model.SettingPath.DefaultFilePath);
        //        if (!dirInfo.Exists)
        //        {
        //            dirInfo.Create();
        //        }
        //        string newPath = Model.SettingPath.DefaultFilePath + "\\" + openFile.SafeFileName;
        //        FileInfo fileInf = new FileInfo(path);
        //        if (fileInf.Exists)
        //        {
        //            fileInf.CopyTo(newPath, true);

        //        }

        //        filename = openFile.SafeFileName;


        //        RaisePropertyChanged("FileName");
        //    }


        //}
    }
}
