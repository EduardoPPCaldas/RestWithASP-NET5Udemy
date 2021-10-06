using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);

        BookVO FindById(long id);

        List<BookVO> FindAll();

        BookVO Update(BookVO book);

        bool Exists(long id);
    }
}
