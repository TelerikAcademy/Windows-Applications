namespace SQLiteDemo
{
    using SQLite.Net.Attributes;

    public class UserItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return $"#{this.Id}; Name: {this.Name}; Price: {this.Price}";
        }
    }
}
