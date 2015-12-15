﻿namespace RaceConditionsSalesSum
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class RaceConditionsSalesSum
    {
        public static void Main()
        {
            var soldItemsForADay = GenerateSoldItemsData();

            Console.WriteLine();
            Console.WriteLine("--DAY-SALES-SEQUENTIAL-----------------------------------");
            Console.WriteLine();

            var daySalesSequential = AggregateDaySales(soldItemsForADay);
            Console.WriteLine(daySalesSequential);

            Console.WriteLine();
            Console.WriteLine("---DAY-SALES-PARALLEL------------------------------------");
            Console.WriteLine();

            var daySalesParallel = AggregateDaySalesParallel(soldItemsForADay);
            Console.WriteLine(daySalesParallel);

            Console.WriteLine();
            Console.WriteLine("What about summing numbers from 1 to 100 with 2 parallel for loops?");
            var x = 0;
            Parallel.For(0, 100, i => Parallel.For(i + 1, 100, a => { x += 1; }));
            Console.WriteLine($"Expected: 4950. Actual: {x}");
        }

        private static DaySales AggregateDaySalesParallel(List<SoldItem> allSales)
        {
            // Note: This code gives me race-condition nightmares. For real.
            var soldItemCounts = new Dictionary<string, int>();
            var totalCents = 0;

            Parallel.ForEach(allSales, (soldItem) =>
            {
                IncludeItemInSoldCounts(soldItem, soldItemCounts);
                totalCents += soldItem.PriceCents;
            });

            return new DaySales(totalCents, soldItemCounts);
        }

        private static DaySales AggregateDaySales(List<SoldItem> allSales)
        {
            Dictionary<string, int> soldItemCounts = new Dictionary<string, int>();
            int totalCents = 0;
            foreach (SoldItem soldItem in allSales)
            {
                IncludeItemInSoldCounts(soldItem, soldItemCounts);
                totalCents += soldItem.PriceCents;
            }

            return new DaySales(totalCents, soldItemCounts);
        }

        private static void IncludeItemInSoldCounts(SoldItem soldItem, Dictionary<string, int> soldItemCounts)
        {
            if (!soldItemCounts.ContainsKey(soldItem.Name))
            {
                soldItemCounts[soldItem.Name] = 1;
            }
            else
            {
                soldItemCounts[soldItem.Name]++;
            }
        }

        private static List<SoldItem> GenerateSoldItemsData()
        {
            var soldItems = new List<SoldItem>();

            // The more items we have, the more often race conditions will arise and the larger the error will be
            for (int i = 0; i < 100; i++)
            {
                soldItems.Add(new SoldItem(100, "Coke"));
                soldItems.Add(new SoldItem(200, "Beer"));
                soldItems.Add(new SoldItem(300, "Beer Nuts"));
                soldItems.Add(new SoldItem(400, "Deer Nuts"));
                soldItems.Add(new SoldItem(500, "HealthyNot Chips"));
                soldItems.Add(new SoldItem(600, "Aisis Pork"));
                soldItems.Add(new SoldItem(700, "Pengiun Stake"));
                soldItems.Add(new SoldItem(800, "Ustillfat Diet Coke"));
                soldItems.Add(new SoldItem(900, "ClimateChangeHoax Aerosol"));
                soldItems.Add(new SoldItem(1000, "McDon'talds Iscream"));
            }

            return soldItems;
        }
    }
}
