using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    abstract class Command
    {
        public abstract void Download(string url, string outputFilePath);
        public abstract void Delete(string path);
        public abstract void ShowInfo(string url);
    }
}
