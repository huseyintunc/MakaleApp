using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.Business.Abstract
{
    public interface IYazarService
    {
        List<Yazar> GetAll();
        Yazar GetById(int yazarId);
        void Add(Yazar yazar);
        void Delete(int yazarId);
        void Update(Yazar yazar);

        void Register(Yazar yazar, string password);
        Yazar Login(string userName, string Password);
        bool UserExists(string userName);
    }
}
