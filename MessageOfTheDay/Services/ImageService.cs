using MessageOfTheDay.Interfaces;

namespace MessageOfTheDay.Services
{
    public class ImageService : IImageService
    {
        public string Format(string dayOfWeek) => "/images/" + dayOfWeek + ".jpg";
    }
}
