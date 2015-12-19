using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace BallsGame.Helpers
{
  public class BindingHelper
  {
    public static string GetCanvasTopBindingPath(DependencyObject obj)
    {
      return (string)obj.GetValue(CanvasTopBindingPathProperty);
    }

    public static void SetCanvasTopBindingPath(DependencyObject obj, string value)
    {
      obj.SetValue(CanvasTopBindingPathProperty, value);
    }

    public static readonly DependencyProperty CanvasTopBindingPathProperty =
        DependencyProperty.RegisterAttached("CanvasTopBindingPath", typeof(string), typeof(BindingHelper), new PropertyMetadata("", HandleCanvasBindingPathChanged));



    public static string GetCanvasLeftBindingPath(DependencyObject obj)
    {
      return (string)obj.GetValue(CanvasLeftBindingPathProperty);
    }

    public static void SetCanvasLeftBindingPath(DependencyObject obj, string value)
    {
      obj.SetValue(CanvasLeftBindingPathProperty, value);
    }

    // Using a DependencyProperty as the backing store for CanvasLeftBindingPath.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CanvasLeftBindingPathProperty =
        DependencyProperty.RegisterAttached("CanvasLeftBindingPath", typeof(string), typeof(BindingHelper), new PropertyMetadata("", HandleCanvasBindingPathChanged));

    private static void HandleCanvasBindingPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var propertyPath = e.NewValue as string;

      if (propertyPath != null)
      {
        var canvasProperty =
            e.Property == CanvasLeftBindingPathProperty
            ? Canvas.LeftProperty
            : Canvas.TopProperty;

        BindingOperations.SetBinding(
            d,
            canvasProperty,
            new Binding { Path = new PropertyPath(propertyPath) });
      }
    }
  }

}
