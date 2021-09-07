using RestWithASPNET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using RestWithASPNET5Udemy.Model.Context;
using RestWithASPNET5Udemy.Repositories;


namespace RestWithASPNET5Udemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }


        public List<Book> FindAll()
        {

            return _repository.FindAll();
        }


        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }


        public Book Create(Book book)
        {
            return _repository.Create(book);
        }


        public Book Update(Book book)
        {

            return _repository.Update(book);

        }


        public void Delete(long id)
        {
            _repository.Delete(id);
        }


    }
}

