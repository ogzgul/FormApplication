using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormApplication.Models
{
    public class Member
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 2, ErrorMessage = "En az 2,en fazla 30 karakter")]
        [DisplayName("İsim")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }
        [StringLength(30, MinimumLength = 2, ErrorMessage = "En az 2,en fazla 30 karakter")]
        [DisplayName("Soyisim")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Surname { get; set; }
        [DisplayName("Yaş")]
        public int? Age { get; set; }
        public string Description { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
