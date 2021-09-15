using RestWithASPNET5Udemy.Model;
using System.Collections.Generic;
using RestWithASPNET5Udemy.Repositories;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Data.Converter.Implementations;

namespace RestWithASPNET5Udemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }


        public List<BookVO> FindAll()
        {

            return _converter.Parse(_repository.FindAll());
        }


        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }


        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }


        public BookVO Update(BookVO book)
        {

            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);

        }


        public void Delete(long id)
        {
            _repository.Delete(id);
        }


    }
}

