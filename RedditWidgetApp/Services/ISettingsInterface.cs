using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditWidgetApp.Services
{
    public interface ISettingsService
    {
        void SetValue<T>(string key, T value);
        
        T GetValue<T>(string key);
    }
}
