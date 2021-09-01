using SocialMedia.Data;
using SocialMedia.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.PostModels
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual List<CommentListItem> Comments { get; set; } = new List<CommentListItem>(); // don't pass entities from the data layer out of the controller
    }
}
