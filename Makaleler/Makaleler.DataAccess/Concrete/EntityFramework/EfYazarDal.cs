using Makaleler.Core.DataAccess.EntityFramework;
using Makaleler.DataAccess.Abstract;
using Makaleler.DataAccess.Context;
using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.DataAccess.Concrete.EntityFramework
{
    public class EfYazarDal : EfEntityRepositoryBase<Yazar, MakalelerContext>, IYazarDal
    {
       
    }
}
