using System;
using System.Threading.Tasks;

namespace MessageOfTheDay.Interfaces
{
    public interface IMessageService
    {
        public Task<string> GetMessageAsync(string languageCode, DayOfWeek dayOfWeek);

        public string FormatPath(string languageCode, DayOfWeek dayOfWeek);
    }
}
