using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Data.Converter.Implementations;

namespace RestWithASPNETUdemy.Business.Implementations
{
  public class PersonBusinessImplementation : IPersonBusiness
  {
    private readonly IRepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonBusinessImplementation(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public List<PersonVO> FindAll()
    {    
        return _converter.Parse(_repository.FindAll());
    }


    public PersonVO FindById(long id)
    {
        return _converter.Parse(_repository.FindByID(id));
    }

    public PersonVO Create(PersonVO person)
    {   
        var personEntity = _converter.Parse(person);
        personEntity = _repository.Create(personEntity);
        return _converter.Parse(personEntity);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public PersonVO Update(PersonVO person)
    {
        var personEntity = _converter.Parse(person);
        personEntity = _repository.Update(personEntity);
        return _converter.Parse(personEntity);
    }
  }
}
