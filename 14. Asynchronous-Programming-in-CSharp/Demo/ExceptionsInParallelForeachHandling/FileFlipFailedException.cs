namespace ExceptionsInParallelForeachHandling
{
    using System;

    public class FileFlipFailedException : Exception
    {
        public FileFlipFailedException(string failedFilepath, Exception reason)
            : base("Failed to process " + failedFilepath + ". See innerException for details", reason)
        {
            this.FailedFilepath = failedFilepath;
        }

        public string FailedFilepath { get; private set; }
    }
}
