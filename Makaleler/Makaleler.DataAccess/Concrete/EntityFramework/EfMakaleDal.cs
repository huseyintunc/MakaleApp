using Makaleler.Core.DataAccess.EntityFramework;
using Makaleler.DataAccess.Abstract;
using Makaleler.DataAccess.Context;
using Makaleler.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makaleler.DataAccess.Concrete.EntityFramework
{
    public class EfMakaleDal : EfEntityRepositoryBase<Makale, MakalelerContext>, IMakaleDal
    {
        public List<Makale> GetSearchAll(string text)
        {
            using (var db=new MakalelerContext())
            {
                var list = db.Makale.Where(i => EF.Functions.Like(i.Icerik.ToLower(), "%" + text.ToLower() + "%") || EF.Functions.Like(i.KisaIcerik.ToLower(), "%" + text.ToLower() + "%") || EF.Functions.Like(i.MakaleBaslik.ToLower(), "%" + text.ToLower() + "%")).ToList();
                return list;
            }
        }
    }
}
