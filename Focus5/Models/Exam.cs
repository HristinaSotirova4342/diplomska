using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Focus5.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string School { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}