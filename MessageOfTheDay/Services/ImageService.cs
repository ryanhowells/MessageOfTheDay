using MessageOfTheDay.Interfaces;
using System;

namespace MessageOfTheDay.Services
{
    public class ImageService : IImageService
    {
        public string Format(DayOfWeek dayOfWeek) => "/images/" + dayOfWeek + ".jpg";
    }
}
