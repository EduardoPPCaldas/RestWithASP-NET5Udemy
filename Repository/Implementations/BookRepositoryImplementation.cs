using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
  public class BookRepositoryImplementation : IBookRepository
  {

    private MySQLContext _context;

    public BookRepositoryImplementation(MySQLContext context)
    {
        _context = context;
    }
    public Book Create(Book book)
    {
        try
        {
            _context.Add(book);
            _context.SaveChanges();
        }
        catch (System.Exception ex)
        {
            
            throw ex;
        }

        return book;
    }

    public bool Exists(long id)
    {
        return _context.Books.Any(b => b.Id.Equals(id));
    }

    public List<Book> FindAll()
    {
        return _context.Books.ToList();
    }

    public Book FindById(long id)
    {
      return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
    }

    public Book Update(Book book)
    {
        if (!Exists(book.Id))
        {
            return null;
        }

        var result = _context.Books.SingleOrDefault(b => b.Id.Equals(book.Id));

        try
        {
            _context.Entry(result).CurrentValues.SetValues(book);
            _context.SaveChanges();
        }
        catch (System.Exception ex)
        {
            
            throw ex;
        }

        return book;
    }
  }
}
