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
   public class ChiefViewModelCRUDTask:ViewModelBase
    {
        private Model.NewTaskBook _task_Book;
        public Model.NewTaskBook Task_Book { get=>_task_Book; set=>_task_Book=value; }


        private bool _isReadOnly = true;
        public bool IsReadOnly { get=>_isReadOnly; set=>_isReadOnly=value; }

        public string CRUDText { get; set; }


       public ChiefViewModelCRUDTask(Model.Enums.CRUD crud, Model.NewTaskBook task_Book =null)
        {
            if (crud==Model.Enums.CRUD.Create)
            {
                _task_Book = new Model.NewTaskBook();
                _isReadOnly = false;
             //   CRUDExcecute = new RelayCommand(() => { Create_Task_Book.Execute(null); });

                CRUDText = crud.ToString();
                MessageBox.Show("tr");

            }
            else if (crud == Model.Enums.CRUD.Update)
            {
                if (task_Book!=null)
                {
                    _task_Book = task_Book;
                    CRUDExcecute = new RelayCommand(()=> { Update_Task_Book.Execute(null); });
                    CRUDText = crud.ToString();
                }
                else
                {
                    MessageBox.Show("UUUUUUU");
                }
            }
            else if (crud == Model.Enums.CRUD.Delete)
            {
                if (task_Book != null)
                {
                    _task_Book = task_Book;
                    CRUDExcecute = new RelayCommand(() => { Delete_Task_Book.Execute(null); });

                    CRUDText = crud.ToString();
                }
                else
                {
                    MessageBox.Show("dddddd");
                }
            }
       }




        private ObservableCollection<string> _listExcecuter=new ObservableCollection<string>(Model.Enums.ListsTypeCategoryTask.RegistryByDev);
        public ObservableCollection<string> ListExcecuter { get=>_listExcecuter; set=>_listExcecuter=value; }

        private ObservableCollection<string> _listNameTask = new ObservableCollection<string>() {"Промо","Задачник", "DWH" };
        public ObservableCollection<string> ListNameTask { get=>_listNameTask; set=>_listNameTask=value; }

        private ObservableCollection<string> _listCategoryTask = new ObservableCollection<string>(Model.Enums.ListsTypeCategoryTask.CategoryTask);

        public ObservableCollection<string> ListCategoryTask { get=>_listCategoryTask; set=>_listCategoryTask=value; }


        private ObservableCollection<string> _listTypeTask =new ObservableCollection<string>(  Model.Enums.ListsTypeCategoryTask.TypeTask);
        public ObservableCollection<string> ListTypeTask { get=>_listTypeTask; set=>_listTypeTask=value; }


        private ObservableCollection<string> _listAffectedProduct = new ObservableCollection<string>() { "Промо", "Задачник", "DWH" };
        public ObservableCollection<string> ListAffectedProduct { get => _listAffectedProduct; set => _listAffectedProduct = value; }


        public RelayCommand CRUDExcecute { get; set; }

        #region Команды
        /// <summary>
        /// Команда для редактирования записи
        /// </summary>
        public RelayCommand Update_Task_Book
        {
            get
            {
                return new RelayCommand(async () => {
                    new Model.CrudOperations.CRUDTask_Book().Update(_task_Book);
                    MessageBox.Show("Записть обновлена");
                });
            }
        }
        /// <summary>
        /// Команда для удаления записи
        /// </summary>
        public RelayCommand Delete_Task_Book
        {
            get
            {
                return new RelayCommand(async () => {
                    new Model.CrudOperations.CRUDTask_Book().Delete(_task_Book);
                    MessageBox.Show("Запись удалена");
                });
            }
        }
        /// <summary>
        /// Команда для создания записи
        /// </summary>
        public RelayCommand Create_Task_Book
        {
            get
            {
                return new RelayCommand(async () => {
                    MessageBox.Show("tr");

                    new Model.CrudOperations.CRUDTask_Book().Create(_task_Book);

                    MessageBox.Show("Запись добавлена");
                });
            }
        }
        #endregion


    }
}
