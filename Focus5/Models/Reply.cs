using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Focus5.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? CreateOn { get; set; }
  
        public string UserName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}