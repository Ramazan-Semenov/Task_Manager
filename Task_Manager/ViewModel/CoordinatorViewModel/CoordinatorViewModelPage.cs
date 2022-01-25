using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;
using Task_Manager.Model;

namespace Task_Manager.ViewModel.CoordinatorViewModel
{
    class CoordinatorViewModelPage : ViewModelBase, IDisposable
    {
        private ObservableCollection<task_book> task_Books;

        public ObservableCollection<task_book> tasks
        {
            get => task_Books; set
            {
                task_Books = value;
            }
        }

        private ObservableCollection<task_book> runtimeTask;

        public ObservableCollection<task_book> RuntimeTask { get => runtimeTask; set => runtimeTask = value; }
        public string Department { get; set; }
        private Model.ConnectionDataBase _con;
        ChangeDataTask_Book changeDataTask;
        public CoordinatorViewModelPage(string Department)
        {

            _con = new ConnectionDataBase();
            this.Department = Department;
            //runtimeTask = new ObservableCollection<task_book>(Model.ListElement.ListElement.Task_Books.Where(x => (x.Department == Department) &  ((x.status == null) || (x.status == string.Empty))));

            runtimeTask = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.Department == Department) & (x.status!= Model.ListElement.ListElement.List_Status[0])));
            task_Books = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.Department == Department)&(x.implicit_request_bool==false) & (x.status == Model.ListElement.ListElement.List_Status[0])));
            changeDataTask = new ChangeDataTask_Book();
            changeDataTask.ChangeData(df);
        }
        private void df(IEnumerable<task_book> task_Book, ConditionOper condition)
        {
            if (condition== ConditionOper.Insert||condition== ConditionOper.Update)
            {

                //new ToastContentBuilder()
                //        .AddArgument("action", "viewConversation")
                //        .AddArgument("conversationId", 9813)
                //        .AddText(task_Book.First().Department)
                //        .AddText(condition.ToString()).Show();
                Debug.WriteLine("++++++++++++++");
                runtimeTask = null;
                runtimeTask = new ObservableCollection<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList().Where(x => (x.Department == Department) & (x.status == null)));
                Debug.WriteLine("================");
            }
            Debug.WriteLine("*****************");

        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
                    View.Coordinator.CoordinatorViewEditTask editTask = new View.Coordinator.CoordinatorViewEditTask(task_book);
                    editTask.ShowDialog();

                    RaisePropertyChanged("RuntimeTask");
                });
            }
        }

    }
}
