using Apartment.Application.DTOs;
using Apartment.Domain.Entities;

namespace Apartment.Application.Services.Persons;

public interface IPersonService
{
    public ValueTask<bool> CreateAsync(PersonDTO personDTO);
    public ValueTask<bool> UpdateAsync(int id, PersonDTO personDTO);
    public ValueTask<bool> DeleteAsync(int id);
    public ValueTask<IList<Person>> GetAllAsync();
    public ValueTask<Person> GetByIdAsync(int id);
    public ValueTask<int> GetCountAsync();
}
