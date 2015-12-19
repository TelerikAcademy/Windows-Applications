namespace DataBinding.ViewModels
{
  using System.ComponentModel;

  public abstract class ViewModelBase : INotifyPropertyChanged
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
