using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PopupMenu
{
    using Windows.UI.Popups;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }

        private async void OnPhoneModelClicked(object sender, RightTappedRoutedEventArgs e)
        {
            var popup = new PopupMenu();
            popup.Commands.Add(new UICommand("Open", (command) =>
            {
                this.TextBoxResult.Text = "Open...";
            }));
            popup.Commands.Add(new UICommand("Open with", (command) =>
            {
                this.TextBoxResult.Text = "Opened with...";
            }));
            popup.Commands.Add(new UICommand("Save with", (command) =>
            {
                this.TextBoxResult.Text = "Save with...";
            }));
            var chosenCommand = await popup.ShowForSelectionAsync(GetElementRect((FrameworkElement)sender));
            if (chosenCommand == null)
            {
                this.TextBoxResult.Text = "Nothing chosen";
            }
        }
    }
}
