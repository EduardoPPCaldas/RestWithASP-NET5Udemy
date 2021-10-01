using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
  public class PersonBusinessImplementation : IPersonBusiness
  {
    private readonly IPersonRepository _repository;

    public PersonBusinessImplementation(IPersonRepository repository)
    {
        _repository = repository;
    }

    public List<Person> FindAll()
    {    
        return _repository.FindAll();
    }


    public Person FindById(long id)
    {
        return _repository.FindById(id);
    }

    public Person Create(Person person)
    {
        
        return _repository.Create(person);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public Person Update(Person person)
    {
        return _repository.Update(person);
    }
  }
}
