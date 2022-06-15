using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RedditWidgetApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.IncrementOCLengthCommand = new RelayCommand(this.AddString, this.CanAddString);
            this.DecrementOCLengthCommand = new RelayCommand(this.RemoveString, this.CanRemoveString);
        }
        
        public ObservableCollection<string> StringList { get; set; } = new ObservableCollection<string>();

        public RelayCommand IncrementOCLengthCommand { get; }
        public RelayCommand DecrementOCLengthCommand { get; }

        private void RemoveString()
        {
            bool initialCanIncrement = this.CanAddString();
            bool initialCanDecrement = this.CanRemoveString();

            this.StringList.RemoveAt(this.StringList.Count - 1);

            if (initialCanDecrement != this.CanRemoveString())
            {
                this.DecrementOCLengthCommand.NotifyCanExecuteChanged();
            }

            if (initialCanIncrement != this.CanAddString())
            {
                this.IncrementOCLengthCommand.NotifyCanExecuteChanged();
            }
        }
        private bool CanRemoveString()
        {
            return this.StringList.Count > 0;
        }

        private void AddString()
        {
            bool initialCanIncrement = this.CanAddString();
            bool initialCanDecrement = this.CanRemoveString();

            this.StringList.Add("Henlo");

            if (initialCanDecrement != this.CanRemoveString())
            {
                this.DecrementOCLengthCommand.NotifyCanExecuteChanged();
            }

            if (initialCanIncrement != this.CanAddString())
            {
                this.IncrementOCLengthCommand.NotifyCanExecuteChanged();
            }
        }
        private bool CanAddString()
        {
            return this.StringList.Count < 5;
        }
    }
}
