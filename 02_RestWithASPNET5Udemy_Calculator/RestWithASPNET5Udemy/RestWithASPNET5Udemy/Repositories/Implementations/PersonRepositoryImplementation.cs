using RestWithASPNET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using RestWithASPNET5Udemy.Model.Context;

namespace RestWithASPNET5Udemy.Repositories.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _personContext;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _personContext = context;
        }

        public List<Person> FindAll()
        {

            return _personContext.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _personContext.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }
        public Person Create(Person person)
        {
            try
            {
                _personContext.Add(person);
                _personContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }
        public Person Update(Person person)
        {
            if(!Exists(person.Id)) return null;

            var result = _personContext.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try

                {
                    _personContext.Entry(result).CurrentValues.SetValues(person);
                    _personContext.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return person;
            
        }

        public void Delete(long id)
        {
            var result = _personContext.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try

                {
                    _personContext.Persons.Remove(result);
                    _personContext.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }       
        
        public bool Exists(long id)
        {
            return _personContext.Persons.Any(p => p.Id.Equals(id));
        }
    }
    
}
