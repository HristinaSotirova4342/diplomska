using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Focus5.Models
{
    public partial class ImageStore
    {
        public ImageStore()
        {
            this.ChangePasswordViewModels = new HashSet<ChangePasswordViewModel>();
        }

        public Nullable<int> Id { get; set; }
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImagePath { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual ApplicationUser User { get; set; }


        public virtual ICollection<ChangePasswordViewModel> ChangePasswordViewModels {get;set;}
    }
}