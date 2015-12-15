namespace ParallelForEach
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static class ParallelForEach
    {
        public static void Main()
        {
            FlipImages("imagesToFlip", "flippedImages");
        }

        private static void FlipImages(string sourceDirectoryPath, string targetDirectoryPath)
        {
            var filesInDirectory = System.IO.Directory.GetFiles(sourceDirectoryPath);

            Parallel.ForEach(filesInDirectory,
                (currentFile) =>
                {
                    string filename = System.IO.Path.GetFileName(currentFile);

                    // Warning: The Console will slow down our loop
                    Console.WriteLine("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);

                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(currentFile);

                    bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(System.IO.Path.Combine(targetDirectoryPath, filename));
                });
        }
    }
}
