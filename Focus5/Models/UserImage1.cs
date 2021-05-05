using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Focus5.Models
{
    public partial class UserImage1
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}