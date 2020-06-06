using MessageOfTheDay.Constants;
using MessageOfTheDay.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace MessageOfTheDay.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Language { get; set; }

        public List<SelectListItem> Languages => new List<SelectListItem> {
            new SelectListItem { Value = LanguageCodes.English, Text = "English" },
            new SelectListItem { Value = LanguageCodes.German, Text = "German" },
            new SelectListItem { Value = LanguageCodes.French, Text = "French" }};

        public string Message;
        public string ImagePath;

        private readonly IWebHostEnvironment _env;
        private readonly IMessageService _messageService;
        private readonly IImageService _imageService;
        private readonly IMemoryCache _cache;

        public IndexModel(IWebHostEnvironment env, IMessageService messageService, IImageService imageService, IMemoryCache cache)
        {
            _env = env;
            _messageService = messageService;
            _imageService = imageService;
            _cache = cache;
        }
        
        public void OnGet()
        {
            string language = _cache.GetOrCreate(CacheKeys.Language, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(5);
                return Language;
            });

            string dayOfWeek = DateTime.UtcNow.DayOfWeek.ToString();

            ImagePath = _imageService.Format(dayOfWeek);
            Message = _messageService.GetMessage(_env.WebRootPath, language, dayOfWeek);
        }

        public IActionResult OnPost()
        {
            _cache.Remove("language");
            _cache.Set("language", Language);

            return RedirectToPage();
        }
    }
}
