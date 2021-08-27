using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.CommentModels
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual List<Reply> Replies { get; set; } = new List<Reply>();
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
