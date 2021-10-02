using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
    private readonly IBookRepository _repository;

    public BookBusinessImplementation(IBookRepository repository)
    {
        _repository = repository;
    }

    public Book Create(Book book)
    {
        return _repository.Create(book);
    }

    public bool Exists(long id)
    {
        return _repository.Exists(id);
    }

    public List<Book> FindAll()
    {
        return _repository.FindAll();
    }

    public Book FindById(long id)
    {
        return _repository.FindById(id);
    }

    public Book Update(Book book)
    {
        return _repository.Update(book);
    }
  }
}
