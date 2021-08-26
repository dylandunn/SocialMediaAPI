using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.Comment_Models
{
    public class CommentListItem
    {
        public Guid AuthorId { get; set; }
        public string Text { get; set; }

        public int PostId { get; set; }
    }
}
