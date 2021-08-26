using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.Comment_Models
{
    public class CommentCreate
    {
        [Required]
        public string Text { get; set; }
       
        public int PostId { get; set; }
    }
}
