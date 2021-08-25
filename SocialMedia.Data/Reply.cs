using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
    }
}
