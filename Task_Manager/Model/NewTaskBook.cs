using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Model
{
    [Table("TaskBook")]
    public class NewTaskBook
    {
        public int Id { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string TypeTask{ get; set; }
        public string NameTask { get; set; }
        public string CategoryTask { get; set; }
        public string AffectedProduct { get; set; }
        public string DescriptionTask { get; set; }
        public string Excecuter { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public int LaborCosts { get; set; }
        public int ActualLaborCosts { get; set; }
        public string Comment { get; set; }

    }
}
