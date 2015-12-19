using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
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

namespace AccelerometerDemos
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      this.InitAccelerometer();
    }

    private async void InitAccelerometer()
    {
      var accelerometer = Accelerometer.GetDefault();
      accelerometer.ReadingChanged += OnAccelerometerReadingChanged;
      accelerometer.Shaken += OnShake;
    }

    private void OnShake(Accelerometer sender, AccelerometerShakenEventArgs args)
    {
      throw new NotImplementedException();
    }

    private void OnAccelerometerReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
    {
      Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
      {
        this.tbx.Text = string.Format("X: {0}", args.Reading.AccelerationX);
        this.tby.Text = string.Format("Y: {0}", args.Reading.AccelerationY);
        this.tbz.Text = string.Format("Z: {0}", args.Reading.AccelerationZ);
      });
    }
  }
}
