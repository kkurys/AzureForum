using System.Threading.Tasks;
using AzureForum.Account.Contracts;
using AzureForum.Posts.Contracts;
using AzureForum.Web.ViewModels;
using AzureForum.Web.ViewModels.Requests;
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
            var model = await _postService.GetLatestPostThreadsAsync(page, threadsPerPage);

            var result = new PostThreadListingViewModel(model);

            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetThreadPosts([FromQuery]string threadId, [FromQuery] int page, [FromQuery] int postsPerPage = 10)
        {
            var model = await _postService.GetThreadPostsAsync(threadId, page, postsPerPage);

            var result = new PostListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateThread([FromBody]CreateThreadRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var thread = await _postService.CreatePostThreadAsync(currentUser, request.Topic);
            await _postService.CreatePostAsync(currentUser, request.Content, thread.Id.ToString());

            var result = new PostThreadViewModel(thread);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreatePost([FromBody]CreatePostRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var post = await _postService.CreatePostAsync(currentUser, request.Content, request.ThreadId);

            var result = new PostViewModel(post);

            return Json(result);
        }
    }
}
