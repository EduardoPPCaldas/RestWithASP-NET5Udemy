using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Generic
{
  public class GenericRepository<T> : IRepository<T> where T : BaseEntity
  {

    private MySQLContext _context;

    private DbSet<T> dataset;

    public GenericRepository(MySQLContext context)
    {
      _context = context;
      dataset = _context.Set<T>();
    }
    public T Create(T item)
    {
      try
      {
        dataset.Add(item);
        _context.SaveChanges();
        return item;
      }
      catch (System.Exception ex)
      {

        throw ex;
      }
    }

    public void Delete(long id)
    {
      var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
      if (result != null)
      {
        try
        {
          dataset.Remove(result);
          _context.SaveChanges();
        }
        catch (System.Exception ex)
        {

          throw ex;
        }
      }

    }

    public bool Exists(long id)
    {
      return dataset.Any(p => p.Id.Equals(id));
    }

    public List<T> FindAll()
    {
      return dataset.ToList();
    }

    public T FindByID(long id)
    {
      return dataset.SingleOrDefault(i => i.Id.Equals(id));
    }

    public T Update(T item)
    {
      var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(item);
          _context.SaveChanges();
          return result;
        }
        catch (System.Exception ex)
        {

          throw ex;
        }
      }
      else
      {
        return null;
      }
    }
  }
}