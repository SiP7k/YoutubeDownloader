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
using YoutubeExplode.Videos.Streams;

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
            File.Delete(path + @"\\" + fileName + ".mpeg");
            Console.WriteLine("Видео удалено");
        }

        public async void Download(string url, string path)
        {
            bool isWorking = true;
            var videoInfo = await _client.Videos.GetAsync(url);
            string fileName = videoInfo.Title + ".mpeg";
            string outputFilePath = path + @"\\" + fileName;

            while (isWorking)
            {
                Console.WriteLine("Выберите тип загрузки:\n1 - обычная(быстрая, но качество 720p30)\n2 - премиум(медленнее, но в наилучшем доступном качестве)");

                switch (Console.ReadLine())
                {
                    case "1":
                        await _client.Videos.DownloadAsync(url, outputFilePath, builder => builder.SetPreset(ConversionPreset.UltraFast));
                        isWorking = false;
                        break;
                    case "2":
                        isWorking = false;
                        DownloadPremium(url, outputFilePath);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Видео загружено\n");
        }
        public async void ShowInfo(string url)
        {
            var videoInfo = await _client.Videos.GetAsync(url);
            Console.WriteLine("Название видео: " + videoInfo.Title);
            Console.WriteLine("Канал: " + videoInfo.Author);
            Console.WriteLine("Продолжительность: " + videoInfo.Duration);
        }
        private async void DownloadPremium(string url, string outputFilePath)
        {
            var streamManifest = await _client.Videos.Streams.GetManifestAsync(url);

            var audioStreamInfo = streamManifest.GetAudioStreams().GetWithHighestBitrate();
            var videoStreamInfo = streamManifest.GetVideoStreams().GetWithHighestVideoQuality();
            var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };

            await _client.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(outputFilePath).Build());
        }
    }
}
