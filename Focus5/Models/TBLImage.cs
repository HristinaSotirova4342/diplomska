using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Focus5.Models
{
    public class TBLImage
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}