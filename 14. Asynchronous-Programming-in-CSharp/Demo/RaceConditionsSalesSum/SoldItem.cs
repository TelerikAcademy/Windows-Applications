namespace RaceConditionsSalesSum
{
    public struct SoldItem
    {
        public SoldItem(int priceCents, string name)
        {
            this.PriceCents = priceCents;
            this.Name = name;
        }

        public int PriceCents { get; private set; }

        public string Name { get; private set; }
    }
}
