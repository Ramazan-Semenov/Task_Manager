using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Task_Manager.ViewModel.Viewing_a_task
{
    public class Viewing_a_task_ViewModel : ViewModelBase
    {
        private Model.task_book _task_Book;
        public Model.task_book task_Book { get => _task_Book; set => _task_Book = value; }
        public ObservableCollection<Model.task_book> list_of_stages { get; set; }
        public List<View.ChiefView.tecon> implicit_request_template { get; set; } = new List<View.ChiefView.tecon>();


        public Viewing_a_task_ViewModel(Model.task_book task_Book)
        {
            _task_Book = task_Book;
            list_of_stages = new ObservableCollection<Model.task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.name_of_the_task == _task_Book.name_of_the_task) & (x.Department == _task_Book.Department)));

            if (task_Book.implicit_request!=null)
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



        public RelayCommand Openfloderfile
        {
            get
            {

                return new RelayCommand(openfloderfile);
            }
        }
        void openfloderfile()
        {

            SaveFileDialog openFile = new SaveFileDialog();
            openFile.FileName = _task_Book.FilePath;
            if (openFile.ShowDialog() == true)
            {
                string path = openFile.FileName;
                DirectoryInfo dirInfo = new DirectoryInfo(Model.SettingPath.DefaultFilePath);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                FileInfo fileInf = new FileInfo(Model.SettingPath.DefaultFilePath + "\\" + _task_Book.FilePath);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(path, true);

                }

                RaisePropertyChanged("FileName");
            }

        }
    }
}
