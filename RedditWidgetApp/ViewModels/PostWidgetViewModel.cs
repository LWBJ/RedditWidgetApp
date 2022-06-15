using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace RedditWidgetApp.ViewModels
{
    public sealed class PostWidgetViewModel: ObservableRecipient, IRecipient<PropertyChangedMessage<RedditWidgetApp.Models.Post>>
    {
        private RedditWidgetApp.Models.Post post;
        public RedditWidgetApp.Models.Post Post
        {
            get => post;
            set => SetProperty(ref post, value);
        }

        public void Receive(PropertyChangedMessage<RedditWidgetApp.Models.Post> message)
        {  
            if (message.Sender.GetType() == typeof(SubredditWidgetViewModel) && message.PropertyName == nameof(SubredditWidgetViewModel.SelectedPost))
            {
                try { 
                    this.Post = message.NewValue;
                } catch(Exception ex) {

                }
            }
        }
    }
}
