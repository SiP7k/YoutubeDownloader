using YoutubeDownloader;
using YoutubeExplode;

namespace YoutubeDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            User user = new User();
            VideoManager videoManager = new VideoManager();

            Console.WriteLine("Введите ссылку на видео для скачивания или команду DELETE для удаления файла");
            string userInput = user.TakeInput();

            if (userInput == "DELETE")
            {
                videoManager.Delete(desktopPath);
            }
            else
            {
                user.SetAction(new DownloadCommand(videoManager));
                videoManager.ShowInfo(userInput);
                Thread.Sleep(1000);
                videoManager.Download(userInput, desktopPath);
                Thread.Sleep(1000000);
            }
        }
    }
}