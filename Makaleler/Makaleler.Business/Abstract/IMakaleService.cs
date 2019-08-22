using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.Business.Abstract
{
    public interface IMakaleService
    {
        List<Makale> GetAll();
        Makale GetById(int makaleId);
        void Add(Makale makale);
        void Delete(int makaleId);
        void Update(Makale makale);

        List<Makale> GetSearchAll(string text);
    }
}
