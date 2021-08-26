using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.Comment_Models
{
    public class CommentDetail
    {
        
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public virtual List<Reply> Replies { get; set; } = new List<Reply>();
        public virtual Post Post { get; set; }
    }
}
