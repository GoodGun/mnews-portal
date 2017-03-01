using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
   
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Display(Name = "Rol Adı: ")]
        [MinLength(3,ErrorMessage ="3 karakterden fazlası girilmelidir!"),MaxLength(20,ErrorMessage ="20 karakterden az değer girilmelidir!")]
        public string RoleName { get; set; }
    }
}
