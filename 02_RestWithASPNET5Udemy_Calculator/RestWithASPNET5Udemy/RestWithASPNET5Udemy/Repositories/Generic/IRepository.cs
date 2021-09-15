using System.Collections.Generic;
using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Model.Base;

namespace RestWithASPNET5Udemy.Repositories

{
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);

    }
}
