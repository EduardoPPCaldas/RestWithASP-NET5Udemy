using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
  public class PersonBusinessImplementation : IPersonBusiness
  {
    private readonly IRepository<Person> _repository;

    public PersonBusinessImplementation(IRepository<Person> repository)
    {
        _repository = repository;
    }

    public List<Person> FindAll()
    {    
        return _repository.FindAll();
    }


    public Person FindById(long id)
    {
        return _repository.FindByID(id);
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
