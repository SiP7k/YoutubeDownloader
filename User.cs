using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    internal class User
    {
        Command _command;
        public void SetAction(Command command)
        {
            _command = command;
        }
        public void Delete(string path)
        {
            _command.Delete(path);
        }

        public void Download(string url, string outputFilePath)
        {
            _command.Download(url, outputFilePath);
        }
        public string TakeInput()
        {
            Console.WriteLine("Введите ссылку на видео для скачивания или команду DELETE для удаления файла");
            string userInput = Console.ReadLine();

            if(userInput.StartsWith("https://") || userInput == "DELETE")
                return userInput;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Неправильный ввод данных\n");
            Console.BackgroundColor = ConsoleColor.Black;
            return TakeInput();
        }
    }
}
