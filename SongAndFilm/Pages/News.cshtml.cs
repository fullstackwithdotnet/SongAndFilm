using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SongAndFilm.Core;
using SongAndFilm.Core.Models;
using SongAndFilm.Persistance;

namespace SongAndFilm.Pages
{
    [AllowAnonymous]

    public class NewsModel : PageModel
    {
        private readonly IAzureDataService _dataService;

        [BindProperty]
        public List<News> News { get; set; }

        public NewsModel(IAzureDataService dataService)
        {
            _dataService = dataService;
            News = new List<News>();
        }
       
        public void OnGet()
        {
            News = _dataService.GetNews();
        }

    }
}
