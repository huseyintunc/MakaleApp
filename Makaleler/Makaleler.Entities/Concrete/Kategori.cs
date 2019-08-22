using Makaleler.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Makaleler.Entities.Concrete
{
    public class Kategori:IEntity
    {
        public int KategoriId { get; set; }

        [Required]
        [StringLength(200)]
        public string KategoriAdi { get; set; }

        public virtual ICollection<Makale> Makaleler { get; set; }
    }
}
