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

        [HttpGet]
        public async Task<JsonResult> GetThreads([FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var result = await _postService.GetLatestPostThreadsAsync(page, threadsPerPage);

            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetThreadPosts([FromQuery]string threadId, [FromQuery] int page, [FromQuery] int postsPerPage = 10)
        {
            var result = await _postService.GetLatestThreadPostsAsync(threadId, page, postsPerPage);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateThread([FromBody] string topic, [FromBody] string content)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var thread = await _postService.CreatePostThreadAsync(currentUser, topic);
            await _postService.CreatePostAsync(currentUser, content, thread.Id.ToString());

            return Json(thread);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreatePost([FromBody] string content, [FromBody] string threadId)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var result = await _postService.CreatePostAsync(currentUser, content, threadId);

            return Json(result);
        }
    }
}
