using Superheroes.ViewModels;
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

namespace Superheroes
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();

      //https://s-media-cache-ak0.pinimg.com/originals/c1/91/6c/c1916cd2bbbd45e67d043096d9c55fb1.jpg
      //https://littlemissobsessivesanatomy.files.wordpress.com/2012/07/happy-batman2.jpg
      var contentViewModel = new SuperheroesContentViewModel();
      contentViewModel.Superheroes = new List<SuperheroesViewModel>()
      {
        new SuperheroesViewModel("Batman", "https://littlemissobsessivesanatomy.files.wordpress.com/2012/07/happy-batman2.jpg", "Everything and cool suit"),
        new SuperheroesViewModel("Ironman", "https://s-media-cache-ak0.pinimg.com/originals/c1/91/6c/c1916cd2bbbd45e67d043096d9c55fb1.jpg", "Smart, Millionare, has a cool suit"),
      };

      this.DataContext = new MainPageViewModel(contentViewModel);
    }
  }
}
