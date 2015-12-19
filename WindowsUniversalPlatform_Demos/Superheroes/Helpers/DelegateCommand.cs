using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Superheroes.Helpers
{
  public class DelegateCommand<T> : ICommand
  {
    private Action<T> execute;

    public DelegateCommand(Action<T> execute)
    {
      this.execute = execute;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      this.execute((T)parameter);
    }
  }
}
