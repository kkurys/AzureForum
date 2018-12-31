using System.Threading.Tasks;
using AzureForum.Account.Contracts;
using AzureForum.Posts.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureForum.Web.Controllers
{
    public class PostsController: BaseController
    {
        private readonly IUserService _userService;
        private readonly IPostsService _postService;

        public PostsController(IPostsService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateThread([FromBody] string topic, [FromBody] string content)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var thread = await _postService.CreatePostThread(currentUser, topic);
            await _postService.CreatePost(currentUser, content, thread.Id.ToString());

            return Json(thread);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreatePost([FromBody] string content, [FromBody] string threadId)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var result = await _postService.CreatePost(currentUser, content, threadId);

            return Json(result);
        }
    }
}
