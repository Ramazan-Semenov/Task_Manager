using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager.ViewModel.ChiefViewModel
{
  public  class ChiefViewModelEditTask: ViewModelBase
    {
        private Model.task_book _task_Book;
        public Model.task_book task_Book { get => _task_Book; set => _task_Book = value; }
        public List<string> liststatus { get { return new List<string> { "принят", "в работе", "завершен" }; } }
        public ChiefViewModelEditTask(Model.task_book task_Book)
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
                    View.ChiefView.ChiefViewCreateTask chiefViewCreateTask = new View.ChiefView.ChiefViewCreateTask(this.task_Book);
                    chiefViewCreateTask.ShowDialog();
                    list_of_stages = new ObservableCollection<Model.task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.name_of_the_task == _task_Book.name_of_the_task));

                    RaisePropertyChanged("list_of_stages");

                });
            }
        }

    }
}
