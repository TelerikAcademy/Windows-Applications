namespace BallsGame.ViewModels
{
  using System.ComponentModel;
  public class BallViewModel : ViewModelBase
  {
    private double size;
    private double top;
    private double left;

    public BallViewModel(double size, double top, double left)
    {
      this.Size = size;
      this.Top = top;
      this.Left = left;
    }

    public double Size
    {
      get
      {
        return this.size;
      }
      set
      {
        if (this.size == value)
        {
          return;
        }
        this.size = value;
        this.RaisePropertyChanged("Size");
      }
    }

    public double Top
    {
      get
      {
        return this.top;
      }
      set
      {
        if (this.top == value)
        {
          return;
        }
        this.top = value;
        this.RaisePropertyChanged("Top");
      }
    }

    public double Left
    {
      get
      {
        return this.left;
      }
      set
      {
        if (this.left == value)
        {
          return;
        }
        this.left = value;
        this.RaisePropertyChanged("Left");
      }
    }
  }
}