using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Task_Manager.Model.CrudOperations
{
    class Crud_Operations_Implicit_Request : ConnectionDataBase, ICrudOperations<list_implicit_request>
    {
        public void Create(list_implicit_request item)
        {
            string txt = "INSERT INTO [dbo].[list_implicit_request]([name],[department],[implicit_request_json]) VALUES(@name,@department,@implicit_request_json)";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                    {
                        name = item.name,
                        department = item.department,
                        implicit_request_json = item.implicit_request_json
                    });
            }
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public list_implicit_request GetEntity(object id)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<list_implicit_request> GetEntityList()
        //{
        //    throw new NotImplementedException();
        //}
        public IEnumerable<list_implicit_request> GetEntityList()
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
        public void Update(list_implicit_request item)
        {
            string txt = @"UPDATE [dbo].[list_implicit_request]
   SET[name] = @name
      ,[department] = @department
      ,[implicit_request_json] = @implicit_request_json
  WHERE id=@id";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt, new
                {
                    name = item.name,
                    department = item.department,
                    implicit_request_json = item.implicit_request_json,
                    id = item.id
                }); ;
            }
        }
    }
}
