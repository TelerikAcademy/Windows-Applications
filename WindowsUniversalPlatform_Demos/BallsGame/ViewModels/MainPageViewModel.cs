using BallsGame.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsGame.ViewModels
{
  public class MainPageViewModel
  {
    private ObservableCollection<BallViewModel> balls;

    public MainPageViewModel()
    {
      this.Speed = 10;
      this.balls = new ObservableCollection<BallViewModel>();
    }

    public int Speed { get; private set; }

    public IEnumerable<BallViewModel> Balls
    {
      get
      {
        return this.balls;
      }
      set
      {
        this.balls.Clear();
        value.ForEach(this.balls.Add);
      }
    }

    public double Height { get; set; }

    public double Width { get; set; }

    public void MoveBalls(double top, double left)
    {
      this.Balls.ForEach(ball =>
      {
        ball.Top += this.Speed * top;
        ball.Left += this.Speed * left;
      });
    }
  }
}
