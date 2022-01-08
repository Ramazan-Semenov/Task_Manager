using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
        }
        private ObservableCollection<task_book> runtimeTask = new ObservableCollection<task_book>();

        public ObservableCollection<task_book> RuntimeTask { get=> runtimeTask; set=> runtimeTask=value; }
        public string Department { get; set; } = Users.Department;
        private Model.ConnectionDataBase _con;
        public StaffViewModelPage()
        {
            _con = new ConnectionDataBase();

            task_Books = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList());
            Start();
        }
        SqlTableDependency<task_book> dep;
        private void Start()
        {

            var mapper = new ModelToTableMapper<task_book>();
            mapper.AddMapping(c => c.Number, "Number");
            mapper.AddMapping(c => c.start_date, "start_date");


            dep = new SqlTableDependency<task_book>(_con.sqlConnectionString, "task_book", mapper: mapper);

            if (dep.Status != TableDependency.SqlClient.Base.Enums.TableDependencyStatus.Starting)
            {
                dep.OnChanged += Changed;
                dep.Start();
            }


        }
        ~StaffViewModelPage()
        {
            dep.Stop();
            dep.Dispose();
        }
        /// <summary>
        /// Позже поработать над проверкой, сделать проверку по id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
          
            if ((e.Entity.executor == Users.Name)&(true))
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    runtimeTask.Add(e.Entity);
                });
            }
           RaisePropertyChanged("RuntimeTask");


        }

    }
}
