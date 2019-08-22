using Makaleler.Business.Abstract;
using Makaleler.DataAccess.Abstract;
using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makaleler.Business.Concrete
{
    public class YazarManager : IYazarService
    {

        private readonly IYazarDal _dal;

        public YazarManager(IYazarDal dal)
        {
            _dal = dal;
        }

        public void Add(Yazar yazar)
        {
            _dal.Add(yazar);
        }

        public void Delete(int yazarId)
        {
            _dal.Delete(new Yazar { YazarId=yazarId});
        }

        public List<Yazar> GetAll()
        {
            return _dal.GetAll();
        }

        public Yazar GetById(int yazarId)
        {
            return _dal.Get(_=>_.YazarId==yazarId);
        }

   
       
        public void Update(Yazar yazar)
        {
            _dal.Update(yazar);
        }

        public bool UserExists(string userName)
        {
            if (_dal.GetAll(_ => _.Username == userName).Any())
            {
                return true;
            }
            return false;
        }
        public Yazar Login(string userName, string Password)
        {

            var yazar = _dal.GetAll(_ => _.Username == userName).FirstOrDefault();
            if (yazar == null)
            {
                return null;
            }
            if (!Core.Helper.UserHelper.VerifyPasswordHash(Password, yazar.PasswordHash, yazar.PasswordSalt))
            {
                return null;
            }
            return yazar;
        }

        public void Register(Yazar yazar, string password)
        {
            byte[] passwordHash, passwordSalt;
            Core.Helper.UserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            yazar.PasswordHash = passwordHash;
            yazar.PasswordSalt = passwordSalt;
            _dal.Add(yazar);
        }
       
    }
}
