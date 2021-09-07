using System.Collections.Generic;
using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Repositories
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
        bool Exists(long id);
    }
}
