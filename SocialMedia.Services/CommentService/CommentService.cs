using SocialMedia.Data;
using SocialMedia.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.CommentService
{
    public class CommentService
    {
        private readonly Guid _authorId;

        public CommentService(Guid authorId)
        {
            _authorId = authorId;
        }

        public async Task<bool> Post(CommentCreate comment)
        {
            var entity = new Comment
            {
                PostId = comment.PostId,
                Text = comment.Text,
                Replies = comment.Replies
            };

            using (var ctx = new ApplicationDbContext())
            {
                var post = await ctx.Post.FindAsync(comment.PostId);
                if (post == null)
                {
                    return false;
                }

                entity.Post = post;
                entity.Post.Comments.Add(entity);
                ctx.Comment.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<IEnumerable<CommentListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Comment
                    .Where(c => c.AuthorId == _authorId)
                    .Select(c => new CommentListItem
                    {
                        Id = c.Id,
                        Text = c.Text,
                        Replies = c.Replies
                    }).ToListAsync();

                return query;
            }
        }

        public async Task<CommentDetail> GetByAuthorId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    await
                    ctx
                    .Comment
                    .Where(c => c.AuthorId == _authorId)
                    .SingleOrDefaultAsync(c => c.Id == id);
                if (comment == null)
                {
                    return null;
                }
                return new CommentDetail
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    Replies = comment.Replies,
                    PostId = comment.PostId
                };
            }
        }

        public async Task<CommentDetail> GetByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    await
                    ctx
                    .Comment
                    .SingleOrDefaultAsync(c => c.PostId == id);
                if(comment == null)
                {
                    return null;
                }
                return new CommentDetail
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    Replies = comment.Replies,
                    PostId = comment.PostId
                };

            }
        }

        public async Task<bool> Put(CommentEdit comment, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldCommentData = await ctx.Comment.FindAsync(id);
                if (oldCommentData == null)
                {
                    return false;
                }
                oldCommentData.Text = comment.Text;

                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldCommentData = await ctx.Comment.FindAsync(id);
                if(oldCommentData == null)
                {
                    return false;
                }
                ctx.Comment.Remove(oldCommentData);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

    }
}


