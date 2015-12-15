namespace Deadlocks
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static class Program
    {
        public static void Main()
        {
            var firstTask = Task.Run(
                () =>
                    {
                        Console.WriteLine("entering A");
                        Thread.Sleep(1000);
                        lock ("first")
                        {
                            Console.WriteLine("A got first lock");
                            Thread.Sleep(1000);
                            lock ("second")
                            {
                                Console.WriteLine("A got second lock");
                            }
                        }

                        Console.WriteLine("exiting A");
                    });

            var secondTask = Task.Run(
                () =>
                    {
                        Console.WriteLine("entering B");
                        Thread.Sleep(1000);
                        lock ("second")
                        {
                            Console.WriteLine("B got second lock");
                            Thread.Sleep(1000);
                            lock ("first")
                            {
                                Console.WriteLine("B got first lock");
                            }
                        }

                        Console.WriteLine("exiting B");
                    });

            Task.WaitAll(firstTask, secondTask);
            Console.WriteLine("All tasks finished!");
        }
    }
}
