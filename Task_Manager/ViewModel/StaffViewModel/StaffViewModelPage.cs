using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.StaffViewModel
{
  public  class StaffViewModelPage: ViewModelBase
    {
     
        private  ObservableCollection<task_book> task_Books;
        public  ObservableCollection<task_book> tasks
        {
            get => task_Books; set
            {
                task_Books = value;
                RaisePropertyChanged("tasks");

            }
        }
        private ObservableCollection<task_book> runtimeTask = new ObservableCollection<task_book>();

        public ObservableCollection<task_book> RuntimeTask { get=> runtimeTask; set=> runtimeTask=value; }
        public string Department { get; set; } = Users.Department;
        private Model.ConnectionDataBase _con;
        public StaffViewModelPage()
        {
            _con = new ConnectionDataBase();
            runtimeTask = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.executor==Users.Name)&(x.Department == Department) & (x.status == null)));

            task_Books = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x=>x.Department==Users.Department));
         
            Start();
        }
        private void Start()
        {

            var mapper = new ModelToTableMapper<task_book>();
            mapper.AddMapping(c => c.Number, "Number");
            mapper.AddMapping(c => c.start_date, "start_date");


            StartDep.dep = new SqlTableDependency<task_book>(_con.sqlConnectionString, "task_book", mapper: mapper);

            if (StartDep.dep.Status != TableDependency.SqlClient.Base.Enums.TableDependencyStatus.Starting)
            {
                StartDep.dep.OnChanged += Changed;
                StartDep.dep.Start();
            }


        }
        ~StaffViewModelPage()
        {
            StartDep.dep.Stop();
        }
        /// <summary>
        /// Позже поработать над проверкой, сделать проверку по id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
          
            if ((e.Entity.executor == Users.Name)&(e.Entity.status==null))
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    runtimeTask.Add(e.Entity);
                });
            }
           RaisePropertyChanged("RuntimeTask");


        }
        public RelayCommand Update
        {
            get
            {

                return new RelayCommand(() =>
                {

                    task_Books = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.Department == Department));
                    runtimeTask = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.Department == Department) & (x.status == string.Empty)));

                    RaisePropertyChanged("tasks");
                    RaisePropertyChanged("RuntimeTask");


                });

            }
        }
        public RelayCommand<task_book> Task_Confirmation
        {
            get
            {
                return new RelayCommand<task_book>((task_book task_book) => {
                    task_book.status = "принят";
                    new Model.CrudOperations.CrudOperations().Update(task_book);
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        runtimeTask.Remove(task_book);
                    });

                    RaisePropertyChanged("RuntimeTask");
                    MessageBox.Show(string.Format("Задача под номером: '{0}' подверждена", task_book.Number));
                });
            }
        }
        public RelayCommand<task_book> Edit_TaskCommand
        {
            get
            {
                return new RelayCommand<task_book>((task_book task_book) => {
                    View.StaffView.StaffViewEditTask editTask = new View.StaffView.StaffViewEditTask(task_book);
                    editTask.ShowDialog();

                    RaisePropertyChanged("RuntimeTask");
                });
            }
        }
        //public RelayCommand Update { get {

        //        return new RelayCommand(() =>
        //        {
        //            task_Books = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.Department == Users.Department));
        //            RaisePropertyChanged("tasks");

        //        });

        //    } }

    }
}
