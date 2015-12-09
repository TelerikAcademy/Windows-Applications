using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Buttons
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnGetDataClick(object sender, RoutedEventArgs e)
        {
            var checkedBoxes = this.CheckBoxContainer.Children
                .Where(btn => btn is CheckBox && ((btn as CheckBox).IsChecked ?? false))
                .Select(btn => (btn as CheckBox).Content.ToString());

            var selectedFuel = this.FuelsContainer.Children
                .Where(btn => btn is RadioButton && ((btn as RadioButton).IsChecked ?? false))
                .Select(btn => (btn as RadioButton).Content.ToString());

            var selectedInduction = this.InductionContainer.Children
                .Where(btn => btn is RadioButton && ((btn as RadioButton).IsChecked ?? false))
                .Select(btn => (btn as RadioButton).Content.ToString());

            List<string> results = new List<string>();
            results.AddRange(checkedBoxes);
            results.AddRange(selectedFuel);
            results.AddRange(selectedInduction);

            this.TextBlockResult.Text = string.Join(", ", results);
        }
    }
}
