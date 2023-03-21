using YoutubeDownloader;
using YoutubeExplode;

namespace YoutubeDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\cavva\OneDrive\Рабочий стол";
            bool isWorking = true;
            User user = new User();
            VideoManager videoManager = new VideoManager();

            while(isWorking)
            {
                string userInput = user.TakeInput();

                if (userInput == "DELETE")
                {
                    videoManager.Delete(path);
                }
                else
                {
                    user.SetAction(new DownloadCommand(videoManager));
                    videoManager.ShowInfo(userInput);
                    Thread.Sleep(1000);
                    videoManager.Download(userInput, path);
                    Thread.Sleep(1000);
                    Console.WriteLine();
                }
            }
        }
    }
}