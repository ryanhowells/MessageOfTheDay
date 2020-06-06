using System;
namespace MessageOfTheDay.Interfaces
{
    public interface IImageService
    {
        public string Format(DayOfWeek dayOfWeek);
    }
}
