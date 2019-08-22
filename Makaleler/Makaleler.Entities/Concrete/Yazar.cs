using Makaleler.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Makaleler.Entities.Concrete
{
    public class Yazar:IEntity
    {
        public int YazarId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz.")]
        [StringLength(150)]
        public string Username { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
    }
}
