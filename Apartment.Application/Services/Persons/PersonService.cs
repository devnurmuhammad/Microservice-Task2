using Apartment.Application.DTOs;
using Apartment.Domain.Entities;
using Apartment.Infrastructure.Repositories.Persons;
using AutoMapper;

namespace Apartment.Application.Services.Persons;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async ValueTask<bool> CreateAsync(PersonDTO personDTO)
    {
        //Person person = _mapper.Map<Person>(personDTO);
        Person person = new Person
        {
            Name = personDTO.Name,
            Age = personDTO.Age,
        };
        var result = await _personRepository.CreateAsync(person);
        return result;
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var person = await _personRepository.DeleteAsync(id);
        if (person)
        {
            return true;
        }
        return false;
    }

    public async ValueTask<IList<Person>> GetAllAsync()
    {
        IList<Person> people = await _personRepository.GetAllAsync();
        return people;
    }

    public async ValueTask<Person> GetByIdAsync(int id)
    {
        Person person = await _personRepository.GetByIdAsync(id);
        return person;
    }

    public async ValueTask<int> GetCountAsync()
    {
        int result = await _personRepository.GetCountAsync();
        return result;
    }

    public async ValueTask<bool> UpdateAsync(int id, PersonDTO personDTO)
    {
        Person? person = await _personRepository.GetByIdAsync(id);
        bool result = await _personRepository.UpdateAsync(id, person);

        return result;
    }
}
