using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using RedditWidgetApp.Models;

namespace RedditWidgetApp.Services
{
    public interface IRedditService
    {
        [Get("/r/{subreddit}/.json")]
        Task<PostsQueryResponse> GetSubredditPostsAsync(string subreddit);
    }
}
