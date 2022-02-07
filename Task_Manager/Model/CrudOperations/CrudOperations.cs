using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Task_Manager.Model.CrudOperations
{
    public class CrudOperations : ConnectionDataBase, ICrudOperations<task_book>
    {
        private bool disposedValue;

        public void Create(task_book item)
        {
            //string txt = "INSERT INTO [dbo].[task_book] " +
            //   "( [Date_of_compilation], [from_whom], [task_type], [name_of_the_task], [start_date], [end_date], [executor], [priority], [status],[Department],[FilePath],[Description],[implicit_request])" +
            //   " VALUES ( @Date_of_compilation, @from_whom, @task_type, @name_of_the_task," +
            //   " @start_date, @end_date, @executor, @priority, @status,@Department,@FilePath,@Description,@implicit_request)";       
            string txt = "[dbo].[sp_InsertTask_book]";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                    {
                        //Numder = item.Number,
                        Date_of_compilation = item.Date_of_compilation,
                        from_whom = item.from_whom,
                        task_type = item.task_type,
                        name_of_the_task = item.name_of_the_task,
                        start_date = item.start_date,
                        end_date = item.end_date,
                        executor = item.executor,
                        priority = item.priority,
                        status = item.status,
                        Department = item.Department,
                        FilePath = item.FilePath,
                        Description = item.Description,
                        implicit_request = item.implicit_request
                    }, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
            }
        }

        public void Delete(object id)
        {
            string txt = "DELETE task_book where Number=@id";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                    {
                        Number = id
                    });
                connection.Close();
            }
        }
        public void Delete(task_book item)
        {
            string txt = "DELETE task_book where Number=@Number";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                    {
                        Number = item.Number
                    });
                connection.Close();
            }
        }


        public task_book GetEntity(object id)
        {
            task_book task_Book = new task_book();
            string txt = "Select * from task_book where Number=@Number";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                task_Book = connection.Query<task_book>(txt,
                    new
                    {
                        Number = id


                    }).First();


                connection.Close();
            }
            return task_Book;
        }
        public IEnumerable<list_implicit_request> GetImplicit_requestList()
        {
            List<list_implicit_request> list_implicit_request = new List<list_implicit_request>();
            string txt = "Select * from list_implicit_request";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                list_implicit_request = connection.Query<list_implicit_request>(txt).AsParallel().ToList();
                connection.Close();
            }

            return list_implicit_request;
        }





        public IEnumerable<task_book> GetEntityList()
        {
            List<task_book> students = new List<task_book>();
            string txt = "Select * from task_book";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<task_book>(txt).AsParallel().ToList();
                connection.Close();
            }



            return students;
        }

        public void Update(task_book item)
        {


            //            string txt = @"
            //UPDATE task_book
            //SET Date_of_compilation = @Date_of_compilation
            //, from_whom = @from_whom
            //, task_type = @task_type
            //, name_of_the_task = @name_of_the_task
            //, start_date = @start_date
            //, end_date = @end_date
            //, executor = @executor
            //, priority = @priority
            //, status = @status
            //,Department=@Department
            //,FilePath=@FilePath
            //,Description=@Description
            //,implicit_request=@implicit_request
            //WHERE Number = @Number";
            string txt = "[dbo].[sp_UpdateTask_book]";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt, new
                {
                    Number = item.Number,
                    Date_of_compilation = item.Date_of_compilation,
                    from_whom = item.from_whom,
                    task_type = item.task_type,
                    name_of_the_task = item.name_of_the_task,
                    start_date = item.start_date,
                    end_date = item.end_date,
                    executor = item.executor,
                    priority = item.priority,
                    status = item.status,
                    Department = item.Department,
                    FilePath = item.FilePath,
                    Description = item.Description,
                    implicit_request = item.implicit_request
                }, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~CrudOperations()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
