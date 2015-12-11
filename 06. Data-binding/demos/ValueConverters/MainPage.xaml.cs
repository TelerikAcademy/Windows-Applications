using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ValueConverters.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ValueConverters
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.ViewModel = new MainPageViewModel()
            {
                Title = "This is a Cat",
                ImgSrc = "http://www.kimballstock.com/pix/CAT/02/CAT-02-JE0307-01P.JPG",
                IsImageVisible = false
            };
        }

        public MainPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void OnShowHideButtonClick(object sender, RoutedEventArgs args)
        {
            this.ViewModel.IsImageVisible = !this.ViewModel.IsImageVisible;
            this.btnShowHide.Content = (this.ViewModel.IsImageVisible) ? "Hide" : "Show";
        }
    }
}
