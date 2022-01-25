using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.StaffViewModel
{
    public class StaffViewModelPage : ViewModelBase
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
        private ObservableCollection<task_book> runtimeTask = new ObservableCollection<task_book>();

        public ObservableCollection<task_book> RuntimeTask { get => runtimeTask; set => runtimeTask = value; }
        ChangeDataTask_Book changeDataTask;
        public string Department { get; set; } = Users.Department;
        private Model.ConnectionDataBase _con;
        public StaffViewModelPage()
        {
            _con = new ConnectionDataBase();
            runtimeTask = new ObservableCollection<task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.Department == Users.Department) & (x.executor == Users.Name) &( (x.status == null) || (x.status ==string.Empty)))) ;

            task_Books = new ObservableCollection<task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.Department == Users.Department) & (x.executor == Users.Name) & ((x.status != null) & (x.status != string.Empty))));
            changeDataTask = new ChangeDataTask_Book();
          changeDataTask.ChangeData(DataChanfe);
          //  Start();
        }
        private void DataChanfe(IEnumerable<task_book> task_Book, ConditionOper condition)
        {
            if (condition == ConditionOper.Insert || condition == ConditionOper.Update)
            {
                
                new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                        .AddText(task_Book.First().Department)
                        .AddText(condition.ToString()).Show();
                runtimeTask = null;
                runtimeTask = new ObservableCollection<task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.Department == Users.Department) & (x.executor == Users.Name) & ((x.status == null) || (x.status == string.Empty))));
                RaisePropertyChanged("RuntimeTask");

            }

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
            //StartDep.dep.Stop();
        }
        /// <summary>
        /// Позже поработать над проверкой, сделать проверку по id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {

            if ((e.Entity.executor == Users.Name) & (e.Entity.status == null))
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

                    task_Books = new ObservableCollection<task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.Department == Users.Department) & (x.executor == Users.Name) & ((x.status != null) & (x.status != string.Empty))));
                    //     runtimeTask = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.Department == Department) & (x.status == string.Empty)));
                    runtimeTask = new ObservableCollection<task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.Department == Users.Department) & (x.executor == Users.Name) & ((x.status == null) || (x.status == string.Empty))));
                    RaisePropertyChanged("tasks");
                    RaisePropertyChanged("RuntimeTask");


                });

            }
        }
        public RelayCommand<task_book> Task_Confirmation
        {
            get
            {
                return new RelayCommand<task_book>((task_book task_book) =>
                {
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
                return new RelayCommand<task_book>((task_book task_book) =>
                {
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
