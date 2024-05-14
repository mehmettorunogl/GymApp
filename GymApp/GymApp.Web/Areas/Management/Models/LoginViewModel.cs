using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Web.Areas.Management.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Mail Alanı Boş Olamaz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Boş Olamaz")]
        public string Password { get; set; }
    }
}
