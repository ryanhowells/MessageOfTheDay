using MessageOfTheDay.Constants;
using MessageOfTheDay.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace MessageOfTheDay.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Language { get; set; }
        
        public string Message;
        public string ImagePath;

        private readonly IWebHostEnvironment _env;
        private readonly IMessageService _messageService;
        private readonly IImageService _imageService;

        public IndexModel(IWebHostEnvironment env, IMessageService messageService, IImageService imageService)
        {
            _env = env;
            _messageService = messageService;
            _imageService = imageService;
        }
        
        public void OnGet()
        {
            DayOfWeek dayOfWeek = DateTime.UtcNow.DayOfWeek;

            var language = Request.Cookies["language"];
            if (language != null)
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)
                };

                Response.Cookies.Append("language", language, options);
            }

            ImagePath = _imageService.Format(dayOfWeek);
            Message = _messageService.GetMessage(_env.WebRootPath, language, dayOfWeek);
        }

        public IActionResult OnPost()
        {
            var existing = Request.Cookies["language"];
            if (existing != Language && Language != null)
                Response.Cookies.Append("language", Language);

            return RedirectToPage();
        }
    }
}
