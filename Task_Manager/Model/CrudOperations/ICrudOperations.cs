using System;
using System.Collections.Generic;

namespace Task_Manager.Model.CrudOperations
{
    interface ICrudOperations<T> : IDisposable
         where T : class
    {
        IEnumerable<T> GetEntityList(); // получение всех объектов
        T GetEntity(object id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(object id); // удаление объекта по id
    }
}
