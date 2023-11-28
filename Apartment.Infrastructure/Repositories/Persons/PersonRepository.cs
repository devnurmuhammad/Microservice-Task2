using Apartment.Domain.Entities;
using Apartment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Apartment.Infrastructure.Repositories.Persons;


public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _apartment_context;

    public PersonRepository(ApplicationDbContext apartment_context)
    {
        _apartment_context = apartment_context;
    }

    public async ValueTask<bool> CreateAsync(Person person)
    {
        await _apartment_context.People.AddAsync(person);
        var result = await _apartment_context.SaveChangesAsync();

        return result > 0;
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        Person? person = await _apartment_context.People.FirstOrDefaultAsync(x => x.Id == id);
        if (person != null)
        {
            _apartment_context.Remove(person);
            await _apartment_context.SaveChangesAsync();

            return true;
        }
        else
        {
            return false;
        }
    }

    public async ValueTask<IList<Person>> GetAllAsync()
    {
        IList<Person> result = await _apartment_context.People.ToListAsync();
        return result;
    }

    public async ValueTask<Person> GetByIdAsync(int id)
    {
        Person? person = await _apartment_context.People.FirstOrDefaultAsync(x => x.Id == id);
        if (person != null)
        {
            return person;
        }
        else
        {
            return new Person();
        }
    }

    public ValueTask<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(int id, Person person)
    {
        Person? user = await _apartment_context.People.FirstOrDefaultAsync(x => x.Id == id);

        _apartment_context.Update(user);
        int result = await _apartment_context.SaveChangesAsync();
        return result > 0;
    }
}
