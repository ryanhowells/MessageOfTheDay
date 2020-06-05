using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Text;

namespace MessageOfTheDay.Pages
{
    public class IndexModel : PageModel
    {
        public string Message;
        public string ImagePath;
        private readonly IWebHostEnvironment _env;

        public IndexModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {
            var dayofWeek = DateTime.UtcNow.DayOfWeek.ToString();
            var path = (_env.WebRootPath + "/messages/" + dayofWeek + ".txt").ToLower();
            string[] todaysMessageArray = System.IO.File.ReadAllLines(path);
            StringBuilder sb = new StringBuilder();
            foreach (string value in todaysMessageArray)
            {
                sb.Append(value);
                _ = sb.Append("\n");
            }

            ImagePath = "/images/" + dayofWeek + ".jpg";
            Message = sb.ToString();
        }
    }
}
