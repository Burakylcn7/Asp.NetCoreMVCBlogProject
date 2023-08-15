using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CoreProje.Models
{
    public class UserRegisterModel
    {
        
        [Required(ErrorMessage = "Lütfen Ad Soyad giriniz !")]
        public string NameSurname { get; set; }

       
        [Required(ErrorMessage = "Lütfen Parola giriniz !")]
        public string Password { get; set; }

        
        [Required(ErrorMessage = "Parola uyuşmuyor, Tekrar deneyiniz.")]
        public string ConfirmPassword { get; set; }

        
        [Required(ErrorMessage = "Lütfen Mail giriniz !")]
        public string Mail { get; set; }

        
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı giriniz !")]
        public string UserName { get; set; }

        [AllowNull]
        public string ImageUrl { get; set; }

        [AllowNull]
        public IFormFile ImageFile { get; set; }
    }
}
