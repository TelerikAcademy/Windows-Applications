using BallsGame.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Windows.Devices.Sensors;
using Windows.UI.Core;

namespace BallsGame
{
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      var accelerometer = Accelerometer.GetDefault();
      accelerometer.ReadingChanged += OnAccelerometerReadingChanged;

      this.ViewModel = new MainPageViewModel()
      {
        Balls = new List<BallViewModel>
        {
          new BallViewModel(25, 0, 0),
          new BallViewModel(45, 100, 0),
          new BallViewModel(55, 0, 100)
        }
      };
    }

    private async void OnAccelerometerReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
    {
      var top = args.Reading.AccelerationZ;
      var left = args.Reading.AccelerationX;
      await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
       {
         this.ViewModel.MoveBalls(top, left);
       });
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
  }
}