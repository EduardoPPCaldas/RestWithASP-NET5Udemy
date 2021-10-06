using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
    private readonly IRepository<Book> _repository;

    private readonly BookConverter _converter;

    public BookBusinessImplementation(IRepository<Book> repository)
    {
        _repository = repository;
        _converter = new BookConverter();
    }

    public BookVO Create(BookVO book)
    {
        var bookEntity = _converter.Parse(book);
        bookEntity = _repository.Create(bookEntity);
        return _converter.Parse(bookEntity);
    }

    public bool Exists(long id)
    {
        return _repository.Exists(id);
    }

    public List<BookVO> FindAll()
    {
        return _converter.Parse(_repository.FindAll());
    }

    public BookVO FindById(long id)
    {
        return _converter.Parse(_repository.FindByID(id));
    }

    public BookVO Update(BookVO book)
    {
        var bookEntity = _converter.Parse(book);
        bookEntity = _repository.Update(bookEntity);
        return _converter.Parse(bookEntity);
    }
  }
}
