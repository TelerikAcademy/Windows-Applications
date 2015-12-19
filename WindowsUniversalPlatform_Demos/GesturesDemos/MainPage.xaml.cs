using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace GesturesDemos
{
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private void theCanvas_DoubleTapped(object sender, TappedRoutedEventArgs e)
    {
      e.Handled = true;
      var position = e.GetPosition(this.theCanvas);
      Canvas.SetTop(this.rect, position.Y);
      Canvas.SetLeft(this.rect, position.X);
    }

    bool isLarge = false;

    private void theCanvas_Holding(object sender, HoldingRoutedEventArgs e)
    {
      e.Handled = true;
      var coeff = 1.5;
      if (isLarge)
      {
        this.rect.Width = this.rect.Width / coeff;
        this.rect.Height = this.rect.Height / coeff;
      }
      else {
        this.rect.Width = this.rect.Width * coeff;
        this.rect.Height = this.rect.Height * coeff;
      }
      isLarge = !isLarge;
    }
    private void theCanvas_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
    {
      //this.rect.Stroke = new SolidColorBrush(Colors.Pink);
      //this.rect.StrokeThickness = 15;
    }

    private void theCanvas_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
      //this.rect.Fill = new SolidColorBrush(Colors.Green);
      if (!(this.rect.RenderTransform is CompositeTransform))
      {
        this.rect.RenderTransform = new CompositeTransform();
      }
      isInInertion = false;
    }

    bool isInInertion = false;

    private void theCanvas_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
      if (isInInertion)
      {
        return;
      }
      var top = Canvas.GetTop(this.rect);
      var left = Canvas.GetLeft(this.rect);

      top += e.Delta.Translation.Y;
      left += e.Delta.Translation.X;

      var scale = e.Delta.Scale;

      //var oldWidth = this.rect.Width;
      //var oldHeight = this.rect.Height;

      //this.rect.Width *= scale;
      //this.rect.Height *= scale;

      //top -= (this.rect.Height - oldHeight) / 2;
      //left -= (this.rect.Width - oldWidth) / 2;

      Canvas.SetTop(this.rect, top);
      Canvas.SetLeft(this.rect, left);

      var transform = this.rect.RenderTransform as CompositeTransform;
      //transform.ScaleX += e.Delta.Scale / 100;
      //transform.ScaleY += e.Delta.Scale / 100;

      transform.CenterX = this.rect.Width / 2;
      transform.CenterY = this.rect.Height / 2;
      transform.Rotation += e.Delta.Rotation;
      //transform.Angle += e.Delta.Rotation;
    }

    private void theCanvas_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
      //this.rect.Fill = new SolidColorBrush(Colors.Purple);
      //this.rect.StrokeThickness = 0;

    }

    private void theCanvas_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingRoutedEventArgs e)
    {
      //isInInertion = true;
      e.RotationBehavior.DesiredDeceleration = 0;
      e.RotationBehavior.DesiredRotation = int.MaxValue;
    }
  }
}
