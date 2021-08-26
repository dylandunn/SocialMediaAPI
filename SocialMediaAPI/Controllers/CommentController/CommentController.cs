using Microsoft.AspNet.Identity;
using SocialMedia.Models.CommentModels;
using SocialMedia.Services.CommentService;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialMediaAPI.Controllers.CommentController
{
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(authorId);
            return service;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CommentCreate comment)
        {
            if (comment == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCommentService();
            var serviceSuccess = await service.Post(comment);
            if (serviceSuccess)
            {
                return Ok();
            }

            return InternalServerError();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var service = CreateCommentService();
            var comment = await service.Get();
            return Ok(comment);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            var service = CreateCommentService();
            var comment = await service.GetByPostId(id);
            return Ok(comment);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(CommentEdit comment, int id)
        {
            if (id < 1 || id != comment.Id || comment == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();
            var serviceSuccess = await service.Put(comment, id);
            if (serviceSuccess)
                return Ok();

            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();

            var service = CreateCommentService();
            var serviceSuccess = await service.Delete(id);
            if (serviceSuccess)
                return Ok();

            return InternalServerError();
        }
    }
}
