using System.Collections.Generic;
using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
