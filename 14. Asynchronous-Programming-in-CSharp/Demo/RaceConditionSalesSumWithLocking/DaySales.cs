namespace RaceConditionSalesSumWithLocking
{
    using System.Collections.Generic;
    using System.Text;

    public struct DaySales
    {
        public DaySales(int totalCents, Dictionary<string, int> soldItemCounts)
        {
            this.TotalCents = totalCents;
            this.SoldItemCounts = soldItemCounts;
        }

        public int TotalCents { get; private set; }

        public Dictionary<string, int> SoldItemCounts { get; private set; }

        public override string ToString()
        {
            StringBuilder soldItemCountsBuilder = new StringBuilder();

            foreach (var entry in this.SoldItemCounts)
            {
                soldItemCountsBuilder.Append(entry.Key + ": " + entry.Value + System.Environment.NewLine);
            }

            // Note: This should really be a formatted string
            return "Total Sales Sum: " + (this.TotalCents / 100.0) + "$" + System.Environment.NewLine +
                   "Sales count by item:" + System.Environment.NewLine +
                   soldItemCountsBuilder.ToString();
        }
    }
}
