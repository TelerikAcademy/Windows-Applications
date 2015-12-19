using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.ViewModels
{
  public interface IPageViewModel
  {
    string Title { get; }

    IContentViewModel ContentViewModel { get; set; }
  }
}
