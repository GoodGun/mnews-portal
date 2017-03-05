using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MinLength(3, ErrorMessage = "3 karakterden fazlası girilmelidir!"), MaxLength(50, ErrorMessage = "50 karakterden az değer girilmelidir!")]
        [Required]
        public string Name { get; set; }

        public int ParentCategoryId { get; set; }

        [MinLength(3, ErrorMessage = "3 karakterden fazlası girilmelidir!"), MaxLength(250, ErrorMessage = "250 karakterden az değer girilmelidir!")]
        public string Url { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Content> Content { get; set; }
    }
}
