using RestWithASPNETErudio.Model;

namespace RestWithASPNETErudio.Services.Implementations
{
    public class PersonServiceImplemetation : IPersonService
    {
        private volatile int count;

        Person IPersonService.Create(Person Person)
        {
            return Person;
        }

        void IPersonService.Delete(long id)
        {
           
        }

        List<Person> IPersonService.FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
               people.Add(person);
            }
            return people;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Nickname" + i,
                LastName = "Person Name" + i,
                Address = "Some place" + i,
                Gender = "Prefer not say"
            };
        }

        Person IPersonService.FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Fabio",
                LastName = "Aron",
                Address = "São Paulo, SP, Brasil",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        Person IPersonService.Update(Person person)
        {
            return person;
        }
    }
}
