namespace DataBinding
{
  using ViewModels;
  using Windows.UI.Xaml.Controls;

  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      this.ViewModel = new MainPageViewModel();
    }

    public MainPageViewModel ViewModel
    {
      get
      {
        return this.DataContext as MainPageViewModel;
      }
      private set
      {
        this.DataContext = value;
      }
    }
  }
}
