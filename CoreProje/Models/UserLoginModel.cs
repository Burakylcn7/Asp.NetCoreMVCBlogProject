using System.ComponentModel.DataAnnotations;

namespace CoreProje.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string password { get; set; }
    }
}
