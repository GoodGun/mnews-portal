using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    //[Table("Image")]
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageUrl { get; set; }

        public Content Content { get; set; }
    }
}
