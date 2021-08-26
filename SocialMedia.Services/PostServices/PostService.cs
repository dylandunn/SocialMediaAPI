using SocialMedia.Data;
using SocialMedia.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.PostServices
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    AuthorId = _userId,
                    Title = model.Title,
                    Text = model.Text
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Post.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Post
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    Id = e.Id,
                                    Title = e.Title,

                                }
                               );
                return query.ToArray();
            }
        }
    }
}
