using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
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

        public Viewing_a_task_ViewModel(Model.task_book task_Book)
        {
            _task_Book = task_Book;
            list_of_stages = new ObservableCollection<Model.task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.name_of_the_task == _task_Book.name_of_the_task) & (x.Department == _task_Book.Department)));
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
