namespace ParallelFor
{
    using System;
    using System.Threading.Tasks;

    public static class ParallelFor
    {

        static void Main(string[] args)
        {
            double[,] firstMatrix =
                {
                    {1, 0, 0},
                    {0, 1, 0},
                    {0, 0, 1}
                };

            double[,] secondMatrix =
                {
                    {1, 0, 2},
                    {0, 2, 2},
                    {0, 0, 3}
                };

            var resultMatrix = new double[3, 3];

            MultiplyMatricesParallel(firstMatrix, secondMatrix, resultMatrix);

            for (var row = 0; row < 3; row++)
            {
                for (var col = 0; col < 3; col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("What about summing numbers from 1 to 100 in parallel?");
            var x = 0;
            Parallel.For(0, 100, i => Parallel.For(i + 1, 100, a => { x += 1; }));
            Console.WriteLine($"Expected: 4950. Actual: {x}");
        }

        private static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
        {
            var matACols = matA.GetLength(1);
            var matBCols = matB.GetLength(1);
            var matARows = matA.GetLength(0);

            Parallel.For(0, matARows, row =>
            {
                for (var col = 0; col < matBCols; col++)
                {
                    double currentCellValue = 0;
                    for (var k = 0; k < matACols; k++)
                    {
                        currentCellValue += matA[row, k] * matB[k, col];
                    }
                    result[row, col] = currentCellValue;
                }
            });
        }
    }
}
