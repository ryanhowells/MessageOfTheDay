namespace MessageOfTheDay.Interfaces
{
    public interface IMessageService
    {
        public string GetMessage(string webRootPath, string languageCode, string dayOfWeek);

        public string FormatPath(string webRootPath, string languageCode, string dayOfWeek);
    }
}
