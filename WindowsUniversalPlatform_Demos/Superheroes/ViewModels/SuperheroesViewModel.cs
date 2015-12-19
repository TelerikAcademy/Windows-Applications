namespace Superheroes.ViewModels
{
  public class SuperheroesViewModel : ViewModelBase
  {
    public string Name { get; set; }

    public string ImgUrl { get; set; }

    public string Powers { get; set; }

    public SuperheroesViewModel()
        : this(string.Empty, string.Empty, string.Empty)
    {
    }


    public SuperheroesViewModel(SuperheroesViewModel newSuperhero)
      : this(newSuperhero.Name, newSuperhero.ImgUrl, newSuperhero.Powers)
    {

    }

    public SuperheroesViewModel(string name, string imgUrl, string powers)
    {
      this.Name = name;
      this.ImgUrl = imgUrl;
      this.Powers = powers;
    }

    public bool Equals(SuperheroesViewModel obj)
    {
      return this.Name == obj.Name &&
        this.Powers == obj.Powers &&
        this.ImgUrl == obj.ImgUrl;
    }
    
    public override bool Equals(object obj)
    {
      var other = obj as SuperheroesViewModel;

      if (other == null)
      {
        return false;
      }
      return this.Equals(other);
    }
  }
}