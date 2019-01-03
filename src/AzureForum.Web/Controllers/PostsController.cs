using System.Text;
using System.Threading.Tasks;
using AzureForum.Account.Contracts;
using AzureForum.Common.Exceptions;
using AzureForum.Data.Models.Account;
using AzureForum.Data.Models.Posts;
using AzureForum.Emails.Contracts;
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
        private readonly IEmailService _emailService;

        public PostsController(
            IPostsService postService,
            IUserService userService,
            IEmailService emailService)
        {
            _postService = postService;
            _userService = userService;
            _emailService = emailService;
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
            var thread = await _postService.GetPostThreadAsync(threadId);

            if (thread == null)
            {
                throw new InvalidPostThreadIdException();
            }

            var model = _postService.GetThreadPosts(thread, page, postsPerPage);

            var result = new PostListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateThread([FromBody]CreateThreadRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var thread = await _postService.CreatePostThreadAsync(currentUser, request.Topic);
            await _postService.CreatePostAsync(currentUser, request.Content, thread);

            var result = new PostThreadViewModel(thread);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreatePost([FromBody]CreatePostRequestViewModel request)
        {
            var currentUser = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);

            var thread = await _postService.GetPostThreadAsync(request.ThreadId);
            if (thread == null)
            {
                throw new InvalidPostThreadIdException();
            }

            var post = await _postService.CreatePostAsync(currentUser, request.Content, thread);

            var threadAuthors = _postService.GetThreadAuthors(thread);

            foreach (var author in threadAuthors)
            {
                if (author.Id.ToString() == currentUser.Id.ToString())
                {
                    continue;
                }

                var content = PreparePostNotificationContent(author, thread);

                await _emailService.SendEmail(author, $"Nowe wiadomości w temacie {thread.Topic}!", content);
            }

            var result = new PostViewModel(post);

            return Json(result);
        }

        private string PreparePostNotificationContent(AzureForumUser user, PostThread thread)
        {
            var sb = new StringBuilder();

            sb.Append($"<h3><b>Witaj {user.UserName}! </b></h3>");
            sb.Append(
                $"Informujemy, ze w dyskusji na temat \"{thread.Topic}\" w ktorej brales udzial pojawil sie nowy post. Mozesz przejsc do tego tematu klikajac <a href=\"{Request.Scheme}://{Request.Host}/thread/{thread.Id}\">TUTAJ</a>");

            return sb.ToString();
        }
    }
}
