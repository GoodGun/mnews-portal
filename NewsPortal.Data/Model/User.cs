using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(20,ErrorMessage ="20 Karakterden fazla olamaz!")]
        [Display(Name="Ad")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "20 Karakterden fazla olamaz!")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Display(Name = "e-mail")]
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Geçerli bir e-mail formatı girmediniz")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "20 Karakterden fazla olamaz!")]
        public string Password { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }

        [Display(Name= "Durumu")]
        public bool IsActive { get; set; }

        public virtual Role Role { get; set; }

    }
}
