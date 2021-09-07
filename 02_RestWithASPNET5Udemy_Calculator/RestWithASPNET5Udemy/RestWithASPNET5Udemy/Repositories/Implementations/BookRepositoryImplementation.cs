using RestWithASPNET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using RestWithASPNET5Udemy.Model.Context;

namespace RestWithASPNET5Udemy.Repositories.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _bookContext;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _bookContext = context;
        }

        public List<Book> FindAll()
        {

            return _bookContext.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _bookContext.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _bookContext.Add(book);
                _bookContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _bookContext.Books.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (result != null)
            {
                try

                {
                    _bookContext.Entry(result).CurrentValues.SetValues(book);
                    _bookContext.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return book;

        }

        public void Delete(long id)
        {
            var result = _bookContext.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try

                {
                    _bookContext.Books.Remove(result);
                    _bookContext.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public bool Exists(long id)
        {
            return _bookContext.Books.Any(p => p.Id.Equals(id));
        }
    }

}
