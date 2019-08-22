using Makaleler.Core.DataAccess;
using Makaleler.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.DataAccess.Abstract
{
    public interface IMakaleDal: IEntityRepository<Makale>
    {
        List<Makale> GetSearchAll(string text);
    }
}
