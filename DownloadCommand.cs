using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    internal class DownloadCommand : Command
    {
        VideoManager _videoManager;

        public DownloadCommand(VideoManager videoManager)
        {
            _videoManager = videoManager;
        }
        public override void Delete(string path)
        {
            _videoManager.Delete(path);
        }

        public override void Download(string url,string outputFilePath)
        {
            _videoManager.Download(url, outputFilePath);
        }

        public override void ShowInfo(string url)
        {
            _videoManager.ShowInfo(url);
        }
    }
}
