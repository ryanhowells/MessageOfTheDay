using MessageOfTheDay.Constants;
using MessageOfTheDay.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MessageOfTheDay.Services
{
    public class MessageService : IMessageService
    {
        private readonly IWebHostEnvironment _env;

        public MessageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> GetMessageAsync(string languageCode, DayOfWeek dayOfWeek)
        {
            var path = FormatPath(languageCode, dayOfWeek);
            string[] todaysMessageArray = await System.IO.File.ReadAllLinesAsync(path);
            StringBuilder sb = new StringBuilder();
            foreach (string value in todaysMessageArray)
            {
                sb.Append(value);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public string FormatPath(string languageCode, DayOfWeek dayOfWeek)
        {
            if (languageCode is null)
                languageCode = LanguageCodes.English;

            return _env.WebRootPath + "/messages/" + languageCode + "/" + dayOfWeek + ".txt";
        }
    }
}
