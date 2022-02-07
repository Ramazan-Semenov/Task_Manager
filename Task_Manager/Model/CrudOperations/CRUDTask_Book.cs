using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Model.CrudOperations
{
   public class CRUDTask_Book
    {


        public string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\Nikita\Nikita\AppData\Sch.mdf;Integrated Security=True";

        public void Create(Model.NewTaskBook  newTaskBook)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                //connection.Open();
                //var affectedRows = connection.Insert(newTaskBook);
                //connection.Close();
            }
        }
        public void Update(Model.NewTaskBook software_Registry)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                //connection.Open();
                //var affectedRows = connection.Update(software_Registry);
                //connection.Close();
            }
        }
        public void Delete(Model.NewTaskBook software_Registry)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                //connection.Open();
                //var affectedRows = connection.Delete(software_Registry);
                //connection.Close();
            }
        }
        public IEnumerable<Model.NewTaskBook> Read()
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.GetAll<Model.NewTaskBook>();
                connection.Close();
                return affectedRows;

            }
        }
    }
}
