using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SongAndFilm.Core;
using SongAndFilm.Core.Models;

namespace SongAndFilm.Pages
{
    [AllowAnonymous]

    public class PlacementsModel : PageModel
    {
        private readonly IAzureDataService _dataService;
        [BindProperty]
        public List<News> News { get; set; }

        public PlacementsModel(IAzureDataService dataService)
        {
            _dataService = dataService;
            News = new List<News>();
        }

        public void OnGet()
        {

            News = _dataService.GetNews();
            News = News.Where(n => n.NewsType.Equals("Placement")).ToList();

        }
    }
}
