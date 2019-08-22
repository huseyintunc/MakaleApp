using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Makaleler.Rest.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı Giriniz.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadnızı Giriniz.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
    }
}
