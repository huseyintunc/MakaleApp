using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.Business.Abstract
{
    public interface IKategoriService
    {
        List<Kategori> GetAll();
        Kategori GetById(int kategoriId);
        void Add(Kategori kategori);
        void Delete(int kategoriId);
        void Update(Kategori kategori);
    }
}
