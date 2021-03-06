using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_Manager.Model.ListElement
{
    public static class ListElement
    {

        public static List<string> List_Status { get { return new List<string> { "принят", "в работе", "завершен" }; } }

        public static List<string> ListDepartment
        {
            get
            {

                return new List<string> { "Прогнозирование продаж ФРОВ",
                    "Развитие отчетности и разработки инстрементов", "Аналитика","Взаимодействие КМ",
                "Регулярная отчетность",
                "Бюджетирование"};
            }
        }
        public static List<string> List_type_task
        {
            get
            {

                return new List<string> { "Разработка", "Прогноз"};
            }
        }
        public static List<task_book> Task_Books { get; } =new List<task_book>(new Model.CrudOperations.CrudOperations().GetEntityList());


        public static List<string> name_task_by_department(string department)
        {
            List<string> name_task = Task_Books.Where(x=>x.Department==department).GroupBy(x=>x.name_of_the_task).Select(x=>x.Key).ToList() ;


            return name_task;
        } 
        public static List<string> staff_by_department(string department)
        {
            List<string> name_task = Task_Books.Where(x => x.Department == department).GroupBy(x=>x.executor).Select(x => x.Key).ToList();


            return name_task;
        }


        public static bool Task_Book_null(task_book task_Book)
        {
            bool result_null = true;
            foreach (var item in task_Book.GetType().GetProperties())
            {
                if (item.GetValue(task_Book) == null)
                {
                    Console.WriteLine(item.Name + " | " + item.GetValue(task_Book) + " Нулевые");
                    result_null = false;
                }

            }

            return result_null;
        }

    }
}
