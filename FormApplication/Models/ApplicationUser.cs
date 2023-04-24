using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FormApplication.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Column(TypeName = "nchar(100)")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Ad Soyad*")]
        [StringLength(100, MinimumLength =5, ErrorMessage = "En az 5,En fazla 100 karakter olmalıdır.")]
        public string Name { get; set; }

        public bool Deleted { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Şifre*")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "En az 8,En fazla 100 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Şifre (tekrar)*")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "En az 8,En fazla 100 karakter olmalıdır.")]
        [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor...")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
      

    }
}
