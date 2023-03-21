using AngleSharp.Html.Dom;
using AngleSharp.Media;
using AngleSharp.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Search;

namespace YoutubeDownloader
{
    internal class VideoManager
    {
        YoutubeClient _client = new YoutubeClient();

        public VideoManager()
        {
        }
        public void Delete(string path)
        {
            Console.WriteLine("Введите название файла без его расширения");
            string fileName = Console.ReadLine();
            File.Delete(path + @"\" + fileName + ".mpeg");
            Console.WriteLine("Видео удалено");
        }

        public async void Download(string url, string path)
        {
            var videoInfo = await _client.Videos.GetAsync(url);
            string fileName = videoInfo.Title + ".mpeg";
            string outputFilePath = path + @"\" + fileName;

            if (Directory.GetFiles(path).Contains(outputFilePath))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Видео с таким именем уже скачено");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                await _client.Videos.DownloadAsync(url, outputFilePath, builder => builder.SetPreset(ConversionPreset.UltraFast));
                Console.WriteLine("Видео загружено\n");
            }
        }
        public async void ShowInfo(string url)
        {
            var videoInfo = await _client.Videos.GetAsync(url);
            Console.WriteLine("Название видео: " + videoInfo.Title);
            Console.WriteLine("Канал: " + videoInfo.Author);
            Console.WriteLine("Продолжительность: " + videoInfo.Duration);
        }
    }
}
