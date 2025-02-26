using RestWithASPNETErudio.Model;

namespace RestWithASPNETErudio.Services
{
    public interface IPersonService
    {
        Person Create(Person Person);
        Person FindByID(long id);
        Person Update(Person person);
        List<Person> FindAll();
        void Delete(long id);
    }
}
