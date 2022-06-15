using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using RedditWidgetApp.Services;

namespace RedditWidgetApp.ViewModels
{
    public sealed class SubredditWidgetViewModel: ObservableRecipient
    {
        public SubredditWidgetViewModel(ISettingsService settingsService)
        {
            this.SettingsService = settingsService;
            this.selectedSubreddit = settingsService.GetValue<string>(nameof(SelectedSubreddit)) ?? this.Subreddits[0];

            this.LoadPostsCommand = new AsyncRelayCommand(this.LoadPostsAsync);
        }

        private readonly ISettingsService SettingsService;
        private readonly IRedditService RedditService = (App.Current as App).Services.GetService<IRedditService>();

        public IAsyncRelayCommand LoadPostsCommand { get;}
        public ObservableCollection<RedditWidgetApp.Models.Post> Posts { get; } = new ObservableCollection<RedditWidgetApp.Models.Post>();
        public IReadOnlyList<string> Subreddits { get; } = new[] { 
            "microsoft",
            "windows",
            "dotnet",
        };

        private string selectedSubreddit;
        public string SelectedSubreddit
        {
            get => this.selectedSubreddit;
            set 
            {
                SetProperty(ref selectedSubreddit, value);
                SettingsService.SetValue(nameof(this.SelectedSubreddit), value);
            }
        }

        private RedditWidgetApp.Models.Post selectedPost;
        public RedditWidgetApp.Models.Post SelectedPost
        {
            get => this.selectedPost;
            set => SetProperty(ref selectedPost, value, true);
        }

        public async Task LoadPostsAsync()
        {
            var response = await this.RedditService.GetSubredditPostsAsync(this.SelectedSubreddit);
            this.Posts.Clear();

            foreach (var item in response.Data.Items)
            {
                Posts.Add(item.Data);
            }
        }
    }
}
