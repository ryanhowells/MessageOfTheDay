using MessageOfTheDay.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace MessageOfTheDay.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Language { get; set; }

        public string Message { get; set; }

        public string ImagePath { get; set; }

        private readonly IMessageService _messageService;
        private readonly IImageService _imageService;

        public IndexModel(IMessageService messageService, IImageService imageService)
        {
            _messageService = messageService;
            _imageService = imageService;
        }
        
        public async Task OnGetAsync()
        {
            DayOfWeek dayOfWeek = DateTime.UtcNow.DayOfWeek;
            string language = Request.Cookies["language"];

            ImagePath = _imageService.Format(dayOfWeek);
            Message = await _messageService.GetMessageAsync(language, dayOfWeek);
        }

        public IActionResult OnPost()
        {
            var existingCookie = Request.Cookies["language"];
            if (existingCookie != Language && Language != null)
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(2),
                    Secure = true,
                    HttpOnly = true
                };

                Response.Cookies.Append("language", Language, options);
            }

            return RedirectToPage();
        }
    }
}
