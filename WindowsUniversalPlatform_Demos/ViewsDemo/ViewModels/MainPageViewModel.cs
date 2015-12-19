using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsDemo.ViewModels
{
  public class MainPageViewModel
  {
    public MainPageViewModel()
    {
    }

    public IEnumerable<CatViewModel> Cats { get; set; }
  }
}
