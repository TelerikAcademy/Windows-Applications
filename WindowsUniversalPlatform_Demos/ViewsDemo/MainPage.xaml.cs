using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ViewsDemo.ViewModels;
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

namespace ViewsDemo
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      this.DataContext = new MainPageViewModel()
      {
        Cats = new List<CatViewModel>
        {
          new CatViewModel {
            Name = "Jordan",
            ImgSrc="https://s-media-cache-ak0.pinimg.com/736x/10/88/d8/1088d85e7efa889935929c8305adee07.jpg",
            Value = "Top"
          },
          new CatViewModel {
            Name = "Pesho",
            ImgSrc="http://www.cats.org.uk/uploads/images/pages/photo_latest14.jpg",
            Value = "Bottom"
          }
        }
      };
    }
  }
}
