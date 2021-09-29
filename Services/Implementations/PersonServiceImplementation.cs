using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using System.Threading;

namespace RestWithASPNETUdemy.Services.Implementations
{
  public class PersonServiceImplementation : IPersonService
  {
    private volatile int count;

    public Person create(Person person)
    {

        return person;
    }

    public void Delete(long id)
    {
        
    }

    public List<Person> findAll()
    {
        List<Person> persons = new List<Person>();
        for(int i=0; i<8; i++)
        {
            Person person = MockPerson(i);
            persons.Add(person);
        }
        return persons;
    }


    public Person findById(long id)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = "Eduardo",
            LastName = "Caldas",
            Address = "Rua cassiano santos",
            Gender = "Masculino"
        };
    }

    public Person update(Person person)
    {
        return person;
    }
    private Person MockPerson(int i)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = "Person Name" + i,
            LastName = "Person LastName" + i,
            Address = "Some address" + i,
            Gender = "Male"
        };
    }

    private long IncrementAndGet()
    {
        return Interlocked.Increment(ref count);
    }
  }
}
