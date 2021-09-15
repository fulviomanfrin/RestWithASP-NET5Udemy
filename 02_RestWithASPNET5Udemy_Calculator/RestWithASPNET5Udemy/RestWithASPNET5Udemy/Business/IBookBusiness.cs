using System.Collections.Generic;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
