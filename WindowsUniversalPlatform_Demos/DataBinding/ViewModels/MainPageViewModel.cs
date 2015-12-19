using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    public MainPageViewModel()
    {
      var name = "Supergirl";
      var powers = "Laser eyes, Flying, Super strength";
      var imgSrc = "http://wwwimage.cbsstatic.com/thumbnails/videos/w848/CBS_Production_Entertainment_VMS/2015/10/22/549504579732/DCAA_Supergirl_FINAL_666001_1296_1280x720_549508675993_673565_640x360.jpg";
      this.SuperheroVM = new SuperheroViewModel(name, powers, imgSrc);
    }

    public string Title
    {
      get
      {
        return "Main Page";
      }
    }
    public SuperheroViewModel SuperheroVM { get; set; }
  }
}
