using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GeolocationDemo
{
  public sealed partial class MainPage : Page
  {
    private Geolocator geolocator;

    public MainPage()
    {
      this.InitializeComponent();

      this.geolocator = new Geolocator();
      this.geolocator.PositionChanged += OnGeolocationPositionchanged;
    }

    private void OnGeolocationPositionchanged(Geolocator sender, PositionChangedEventArgs args)
    {
      var lat = args.Position.Coordinate.Latitude;
      var lon = args.Position.Coordinate.Longitude;

      Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
      {
        this.tbLat.Text = string.Format("Latitude: {0}", lat);
        this.tbLon.Text = string.Format("Longitude: {0}", lon);
      });
    }
  }
}
