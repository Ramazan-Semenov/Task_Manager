using System.Collections.Generic;

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
        public static IEnumerable<task_book> Task_Books { get; } = new Model.CrudOperations.CrudOperations().GetEntityList();
    }
}
