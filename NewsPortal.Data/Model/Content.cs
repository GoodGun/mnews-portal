using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    public class Content
    {   
        [Key]
        public int ContentId { get; set; }

        [Required]
        [MinLength(50,ErrorMessage ="50 karakterden fazla başlık girişi olmasın!")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }


        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [Display(Name = "Uzun Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Durum")]
        public int Status { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Yayın Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "Resim")]
        public string Image { get; set; }

        public virtual User User { get; set; }

        //birden fazla resim eklemememiz gerekebileceginden dolayı Image tablosu ile baglantı oluşturuyoruz.
        public virtual ICollection<Image> Images { get; set; }

        public virtual Category Category { get; set; }
    }
}
