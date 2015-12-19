using Superheroes.Extensions;
using Superheroes.Helpers;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Superheroes.ViewModels
{
  public class SuperheroesContentViewModel : ViewModelBase, IContentViewModel
  {
    public ObservableCollection<SuperheroesViewModel> superheroes;
    private ICommand saveCommand;
    private ICommand deleteCommand;

    public IEnumerable<SuperheroesViewModel> Superheroes
    {
      get
      {
        if (this.superheroes == null)
        {
          this.superheroes = new ObservableCollection<SuperheroesViewModel>();
        }

        return this.superheroes;
      }
      set
      {
        if (this.superheroes == null)
        {
          this.superheroes = new ObservableCollection<SuperheroesViewModel>();
        }

        this.superheroes.Clear();
        value.ForEach(this.superheroes.Add);
      }
    }

    public ICommand Save
    {
      get
      {
        if (this.saveCommand == null)
        {
          this.saveCommand = new DelegateCommand<SuperheroesViewModel>((newSuperhero) =>
          {
            this.superheroes.Add(new SuperheroesViewModel(newSuperhero));
          });
        }
        return this.saveCommand;
      }
    }

    public ICommand Delete
    {
      get
      {
        if (this.deleteCommand == null)
        {
          this.deleteCommand = new DelegateCommand<SuperheroesViewModel>((superhero) =>
          {
            this.superheroes.Remove(superhero);
          });
        }
        return this.deleteCommand;
      }
    }
  }
}
