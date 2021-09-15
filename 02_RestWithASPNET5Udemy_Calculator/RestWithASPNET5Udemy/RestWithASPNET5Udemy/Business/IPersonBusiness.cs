using System.Collections.Generic;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);

    }
}
