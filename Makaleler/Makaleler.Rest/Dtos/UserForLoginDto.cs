using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Makaleler.Rest.Dtos
{
    public class UserForLoginDto
    {

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz.")]
        [Display(Name ="Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
