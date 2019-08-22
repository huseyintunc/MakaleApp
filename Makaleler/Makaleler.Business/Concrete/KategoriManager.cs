using Makaleler.Business.Abstract;
using Makaleler.DataAccess.Abstract;
using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.Business.Concrete
{
    public class KategoriManager : IKategoriService
    {
        private readonly IKategoriDal _dal;

        public KategoriManager(IKategoriDal dal)
        {
            _dal = dal;
        }
        public void Add(Kategori kategori)
        {
            _dal.Add(kategori);
        }

        public void Delete(int kategoriId)
        {
            _dal.Delete(new Kategori { KategoriId=kategoriId});
        }

        public List<Kategori> GetAll()
        {
            return _dal.GetAll();
        }

        public Kategori GetById(int kategoriId)
        {
            return _dal.Get(_=>_.KategoriId==kategoriId);
        }

        public void Update(Kategori kategori)
        {
            _dal.Update(kategori);
        }
    }
}
