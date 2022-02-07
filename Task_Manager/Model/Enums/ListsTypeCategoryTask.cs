using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Model.Enums
{
   public static class ListsTypeCategoryTask
   {
          public static  List<string> TypeProduct 
          { 
                get
                {
                    return new List<string>() {"Excel(VBA)",
                        "Excel(формулы)",
                        "C# WPF",
                        "C# Console",
                        "C# WCF",
                        "C# Worker",
                        "DWH",
                        "ETL"               
                    };
                } 
          }
         public static List<string> RegistryByStages 
         {
            get
            {
                return new List<string>() { "В разработке",
                    "Заморожен",
                    "Ожидание",
                    "Разработан",
                    "Отменен"                
                
                };
            }
        
         } 
        public static List<string> RegistryByCurrent
        {
            get
            {
                return new List<string>() { "В рабоде",
                    "Приостановлена",
                    "Ожидание 3-й стороны",
                    "Не начата",
                    "Отменена"                
                
                };
            }        
         }
        public static List<string> RegistryByDev
        {
            get
            {
                return new List<string>() { "Соловьева Оля",
                    "Коротченко Сергей",
                    "Кат Тимур",
                    "Емельянова Светлана",
                    "Кузнецова Маргарита",
                    "Выдрин Никита",
                    "Семенов Рамазан",
                    "Ходус Александр",
                    "Михальченко Паввел"
                
                };
            }        
        }
        public static List<string> CategoryTask
        {
            get
            {
                return new List<string>()
                {
                    "Регулярная",
                    "Разработка",
                    "Сопровождение",
                    "Тестирование",
                    "Документация"
                };
            }
        }
        public static List<string> TypeTask
        {
            get
            {
                return new List<string>()
                {
                    "Временный",
                    "Регулярная"
                };
            }
        }
        

   }
}
