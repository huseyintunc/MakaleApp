using Makaleler.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Makaleler.Entities.Concrete
{
    public class Makale:IEntity
    {
        public int MakaleId { get; set; }

        [Required]
        //[StringLength(300)]
        public string MakaleBaslik { get; set; }

        [Required]
        //[StringLength(500)]
        public string KisaIcerik { get; set; }

        [Required]
        public string Icerik { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [UIHint("datetime")]
        public DateTime EklenmeTarihi { get; set; }

        [DataType(DataType.DateTime)]
        [UIHint("datetime")]
        public DateTime? GuncellenmeTarihi { get; set; }

        [Required]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int YazarId { get; set; }
        public virtual Yazar Yazar { get; set; }
        [Required]
        public int Goruntulenme { get; set; } = 0;

        [Required]
        public bool Aktif { get; set; } = true;

    }
}
