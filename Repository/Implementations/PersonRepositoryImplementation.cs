using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
  public class PersonRepositoryImplementation : IPersonRepository
  {
    private MySQLContext _context;

    public PersonRepositoryImplementation(MySQLContext context)
    {
        _context = context;
    }

    public List<Person> FindAll()
    {
        
        return _context.Persons.ToList();
    }


    public Person FindById(long id)
    {
        return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
    }

    public Person Create(Person person)
    {
        try
        {
             _context.Add(person);
             _context.SaveChanges();
        }
        catch (System.Exception ex)
        {
            
            throw ex;
        }
        return person;
    }

    public void Delete(long id)
    {
        var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

        if(result != null)
        {
            try
            {
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
    }

    

    public Person Update(Person person)
    {
        if(!Exists(person.Id))
        {
            return null;
        }

        var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

        if(result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }

        return person;
    }

    public bool Exists(long id)
    {
      return _context.Persons.Any(p => p.Id.Equals(id));
    }
  }
}
