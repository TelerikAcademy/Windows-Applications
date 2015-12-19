namespace NavigationDemos
{
  using Pages;
  using System;
  using Windows.ApplicationModel;
  using Windows.ApplicationModel.Activation;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls;
  using Windows.UI.Xaml.Navigation;

  sealed partial class App : Application
  {
    public App()
    {
      this.InitializeComponent();
      this.Suspending += OnSuspending;
    }

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {

#if DEBUG
      if (System.Diagnostics.Debugger.IsAttached)
      {
        this.DebugSettings.EnableFrameRateCounter = true;
      }
#endif

      AppShell shell = Window.Current.Content as AppShell;

      if (shell == null)
      {
        shell = new AppShell();

        shell.AppFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
          //TODO: Load state from previously suspended application
        }

        Window.Current.Content = shell;
      }

      if (shell.AppFrame.Content == null)
      {
        shell.AppFrame.Navigate(typeof(HomePage), e.Arguments);
      }
      Window.Current.Activate();
    }

    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }

    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
      var deferral = e.SuspendingOperation.GetDeferral();
      //TODO: Save application state and stop any background activity
      deferral.Complete();
    }
  }
}
