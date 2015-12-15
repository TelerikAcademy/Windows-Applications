namespace SQLiteDemo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;

    using Windows.Storage;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitAsync();
        }

        private async void AddNewItemButtonClick(object sender, RoutedEventArgs e)
        {
            var price = 0;
            int.TryParse(this.PriceTextBox.Text, out price);
            var item = new UserItem
            {
                Name = this.NameTextBox.Text,
                Price = price
            };

            await this.InsertUserAsync(item);
        }

        private async void GetAllButtonClick(object sender, RoutedEventArgs e)
        {
            var userData = await this.GetAllUserAsync();
            var userDataAsString = new StringBuilder();
            foreach (var userItem in userData)
            {
                userDataAsString.AppendLine(userItem.ToString());
            }

            this.AllItemsTextBlock.Text = userDataAsString.ToString();
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTableAsync<UserItem>();
        }

        private async Task<int> InsertUserAsync(UserItem item)
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.InsertAsync(item);
            return result;
        }

        private async Task<List<UserItem>> GetAllUserAsync()
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.Table<UserItem>().ToListAsync();
            return result;
        }
    }
}
