using MessageOfTheDay.Constants;
using MessageOfTheDay.Interfaces;
using System.Text;

namespace MessageOfTheDay.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage(string webRootPath, string languageCode, string dayOfWeek)
        {
            var path = FormatPath(webRootPath, languageCode, dayOfWeek);
            string[] todaysMessageArray = System.IO.File.ReadAllLines(path);
            StringBuilder sb = new StringBuilder();
            foreach (string value in todaysMessageArray)
            {
                sb.Append(value);
                _ = sb.Append("\n");
            }

            return sb.ToString();
        }

        public string FormatPath(string webRootPath, string languageCode, string dayOfWeek)
        {
            if (languageCode is null)
                languageCode = LanguageCodes.English;

            return webRootPath + "/messages/" + languageCode + "/" + dayOfWeek + ".txt";
        }
    }
}
