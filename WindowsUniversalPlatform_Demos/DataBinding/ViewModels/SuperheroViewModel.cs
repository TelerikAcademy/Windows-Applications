using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding.ViewModels
{
  public class SuperheroViewModel : ViewModelBase
  {
    public SuperheroViewModel(string name, string powers, string imgSrc)
    {
      this.Name = name;
      this.Powers = powers;
      this.ImgSrc = imgSrc;
    }

    public string Name { get; private set; }
    public string Powers { get; private set; }
    public string ImgSrc { get; private set; }
  }
}
