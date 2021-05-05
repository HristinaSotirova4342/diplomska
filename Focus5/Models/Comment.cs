using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Focus5.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UserName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}