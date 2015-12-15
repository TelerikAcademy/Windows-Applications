namespace ExceptionsInParallelForeachHandling
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ExceptionsInParallelLoopsHandling
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a directory with images to flip (sourceImages):");
            var imagesDirectory = Console.ReadLine();

            var imageFilepaths = Directory.GetFiles(imagesDirectory).ToList();

            Console.WriteLine("Found the following files:");
            Console.WriteLine(string.Join(System.Environment.NewLine, imageFilepaths));
            Console.Write("Would you like to flip them ? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                FlipImagesWithOptionalRetry(imageFilepaths, "flippedImages");
            }
        }

        private static void FlipImage(string filepath, string targetDirectoryPath)
        {
            Directory.CreateDirectory(targetDirectoryPath);

            var bitmap = new Bitmap(filepath);
            
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);

            bitmap.Save(Path.Combine(targetDirectoryPath, Path.GetFileName(filepath)));
        }

        private static void FlipImages(List<string> filepathsToFlip, string targetDirectoryPath)
        {
            var exceptions = new ConcurrentQueue<FileFlipFailedException>();
            Parallel.ForEach(filepathsToFlip,
                (filepath) =>
                {
                    try
                    {
                        FlipImage(filepath, targetDirectoryPath);
                    }

                    // Note: catching all exceptions like this is not a good practice in production code. A better approach is to handle specific types of 
                    // exceptions (i.e. file not found, GDI exception, etc.) and handle them separately. However, for the purposes of this demo this should 
                    // be enough, to avoid more complicated code
                    catch (Exception e)
                    {
                        // Instead of failing all (remaining) flips just because one of them failed, just "log" the exception so higher-level code can 
                        // decide what to do with failed files (e.g. reprocess them)
                        exceptions.Enqueue(new FileFlipFailedException(filepath, e));
                    }
                });

            if (!exceptions.IsEmpty)
            {
                throw new AggregateException("One or more files failed processing", exceptions);
            }
        }

        private static void FlipImagesWithOptionalRetry(List<string> imageFilepaths, string targetDirectoryPath)
        {
            while (imageFilepaths.Count > 0)
            {
                try
                {
                    FlipImages(imageFilepaths, targetDirectoryPath);
                    imageFilepaths.Clear();
                }
                catch (AggregateException e)
                {
                    imageFilepaths.Clear();
                    var failedFilepaths = new List<string>();
                    foreach (var exception in e.InnerExceptions)
                    {
                        var flipFailed = exception as FileFlipFailedException;
                        if (flipFailed != null)
                        {
                            failedFilepaths.Add(flipFailed.FailedFilepath);
                        }
                    }

                    Console.WriteLine("The following files could not be flipped due to errors:");
                    Console.WriteLine(string.Join(System.Environment.NewLine, failedFilepaths));

                    Console.Write("Would you like to reprocess them? (y/n): ");
                    if (Console.ReadLine()[0] == 'y')
                    {
                        imageFilepaths.AddRange(failedFilepaths);
                    }
                }
            }
        }
    }
}
