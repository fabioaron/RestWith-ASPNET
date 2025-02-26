using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithASPNETErudio.Model;
using RestWithASPNETErudio.Model.Context;
using System;

namespace RestWithASPNETErudio.Services.Implementations
{
    public class PersonServiceImplemetation : IPersonService
    {
        private MySqlContext _context;

        public PersonServiceImplemetation(MySqlContext context)
        {
            _context = context;
        }
        List<Person> IPersonService.FindAll()
        {
            return _context.People.ToList();
        }


        public Person FindByID(long id) => _context.People.SingleOrDefault(p => p.Id.Equals(id));

        Person IPersonService.Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return person;

        }

        void IPersonService.Delete(long id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }
        private bool Exists(long id)
        {
           return _context.People.Any(p => p.Id.Equals(id));
        }
    }
}
