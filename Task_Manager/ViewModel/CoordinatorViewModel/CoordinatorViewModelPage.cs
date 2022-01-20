using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
    class CoordinatorViewModelPage : ViewModelBase
    {


        private ObservableCollection<task_book> task_Books;
       
        public ObservableCollection<task_book> tasks
        {
            get => task_Books; set
            {
                task_Books = value;
                RaisePropertyChanged("tasks");
            }
        }

        private ObservableCollection<task_book> runtimeTask;

        public ObservableCollection<task_book> RuntimeTask { get => runtimeTask; set => runtimeTask = value; }
        public string Department { get; set; }
        private Model.ConnectionDataBase _con;

        public CoordinatorViewModelPage(string Department)
        {

            _con = new ConnectionDataBase();
            this.Department = Department;
            runtimeTask = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.Department == Department) & (x.status == null)));
            //MessageBox.Show(Department);
            task_Books = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => x.Department == Department));
            //MessageBox.Show(task_Books.Count.ToString());
            //     Start();
            // milliseconds to one hour

            /*TaskMetod(interval60Minutes);*/
            Thread thread = new Thread(TaskMetod);
            thread.Start();
        }

        private void TaskMetod()
        {
            const double interval60Minutes = 300000;
           System.Timers.Timer checkForTime = new System.Timers.Timer(interval60Minutes);
           checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            checkForTime.Enabled = true;
        }

        void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            //MessageBox.Show("ok");
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    runtimeTask = null;
                    runtimeTask = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.Department == Department) & (x.status == null)));
                });
            
            RaisePropertyChanged("RuntimeTask");
        }
        private void Start()
        {

            var mapper = new ModelToTableMapper<task_book>();
            mapper.AddMapping(c => c.Number, "Number");
            mapper.AddMapping(c => c.start_date, "start_date");


            Model.StartDep.dep = new SqlTableDependency<task_book>(_con.sqlConnectionString, "task_book", mapper: mapper);

            if (StartDep.dep.Status != TableDependency.SqlClient.Base.Enums.TableDependencyStatus.Starting)
            {
                StartDep.dep.OnChanged += Changed;
                StartDep.dep.Start();
            }


        }
        ~CoordinatorViewModelPage()
        {
           // StartDep.dep.Stop();
        }
        /// <summary>
        /// Позже поработать над проверкой, сделать проверку по id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
            if ((e.ChangeType == TableDependency.SqlClient.Base.Enums.ChangeType.Insert) ||
                (e.ChangeType == TableDependency.SqlClient.Base.Enums.ChangeType.Update))
            {
                if (e.Entity.Department == Department)
                {
                    MessageBox.Show("Ok");
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        runtimeTask.Add(e.Entity);
                    });
                }
                RaisePropertyChanged("RuntimeTask");
            }


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
                    View.Coordinator.CoordinatorViewEditTask editTask = new View.Coordinator.CoordinatorViewEditTask(task_book);
                    editTask.ShowDialog();

                    RaisePropertyChanged("RuntimeTask");
                });
            }
        }

    }
}
