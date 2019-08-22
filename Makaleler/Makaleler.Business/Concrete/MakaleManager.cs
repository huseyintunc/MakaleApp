using Makaleler.Business.Abstract;
using Makaleler.DataAccess.Abstract;
using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.Business.Concrete
{
    public class MakaleManager : IMakaleService
    {
        private readonly IMakaleDal _dal;

        public MakaleManager(IMakaleDal dal)
        {
            _dal = dal;
        }

        public void Add(Makale makale)
        {
            _dal.Add(makale);
        }

        public void Delete(int makaleId)
        {
            _dal.Delete(new Makale { MakaleId = makaleId });
        }

        public List<Makale> GetAll()
        {
            return _dal.GetAll();
        }

        public Makale GetById(int makaleId)
        {
            return _dal.Get(_ => _.MakaleId == makaleId);
        }

        public List<Makale> GetSearchAll(string text)
        {
            return _dal.GetSearchAll(text);
        }

        public void Update(Makale makale)
        {
            _dal.Update(makale);
        }
    }
}
