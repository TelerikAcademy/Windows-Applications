using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ViewsDemo.Controls
{
  public sealed partial class TitledImage : UserControl
  {
    public TitledImage()
    {
      this.InitializeComponent();
    }

    public ICommand Swipe
    {
      get { return (ICommand)GetValue(SwipeProperty); }
      set { SetValue(SwipeProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Swipe.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SwipeProperty =
        DependencyProperty.Register("Swipe", typeof(ICommand), typeof(TitledImage), new PropertyMetadata(null, new PropertyChangedCallback(HandleSwipeChanged));

    private static void HandleSwipeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var control = d as TitledImage;
      var command = e.NewValue as ICommand;
      control.ManipulationDelta += (sender, args) =>
      {
        command.Execute(args);
      };
    }

    public string Title
    {
      get { return (string)GetValue(TitleProperty); }
      set { SetValue(TitleProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(TitledImage), new PropertyMetadata(null, new PropertyChangedCallback(HandleTitleChanged)));

    public string Source
    {
      get { return (string)GetValue(SourceProperty); }
      set { SetValue(SourceProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(string), typeof(TitledImage), new PropertyMetadata(null, new PropertyChangedCallback(HandleSourceChanged)));

    public string TitlePosition
    {
      get { return (string)GetValue(TitlePositionProperty); }
      set { SetValue(TitlePositionProperty, value); }
    }

    // Using a DependencyProperty as the backing store for TitlePosition.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TitlePositionProperty =
        DependencyProperty.Register("TitlePosition", typeof(string), typeof(TitledImage), new PropertyMetadata("Top", new PropertyChangedCallback(HandleTitlePositionChanged)));

    private static void HandleTitlePositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var control = d as TitledImage;
      var titlePosition = e.NewValue.ToString();
      if (titlePosition == "Bottom")
      {
        control.gridTitleBottom.Visibility = Visibility.Visible;
        control.gridTitleTop.Visibility = Visibility.Collapsed;
      }
      else
      {
        control.gridTitleTop.Visibility = Visibility.Visible;
        control.gridTitleBottom.Visibility = Visibility.Collapsed;
      }
    }

    private static void HandleSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var control = d as TitledImage;
      var newValue = e.NewValue.ToString();
      var imageSource = new BitmapImage(new Uri(newValue));
      control.image1.Source = imageSource;
      control.image2.Source = imageSource;
    }
    private static void HandleTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var control = d as TitledImage;
      var newValue = e.NewValue.ToString();
      control.tb1.Text = newValue;
      control.tb2.Text = newValue;
    }
  }
}
