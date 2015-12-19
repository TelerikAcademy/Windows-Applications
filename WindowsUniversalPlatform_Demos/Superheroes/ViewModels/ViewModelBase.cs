using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.ViewModels
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
      if (this.PropertyChanged == null)
      {
        return;
      }

      this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
