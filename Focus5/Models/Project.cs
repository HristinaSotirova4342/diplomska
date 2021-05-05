using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Focus5.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string State { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

      

        [DataType(DataType.MultilineText)]
        public string ProjectDescription { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
 
}