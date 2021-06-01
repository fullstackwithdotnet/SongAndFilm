using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SongAndFilm.Core;
using SongAndFilm.Core.Models;

namespace SongAndFilm.Pages.Admin
{
    [Authorize]
    public class AddNewsModel : PageModel
    {
        private readonly IAzureDataService _dataService;

        public AddNewsModel(IAzureDataService dataService)
        {
            _dataService = dataService;
        }

        [BindProperty]
        public News News { get; set; }
        [BindProperty]
        public List<News> NewsList { get; set; }

        public void OnGet()
        {
            NewsList = _dataService.GetNews();
        }      
        public IActionResult OnPost(News news)
        {
            _dataService.AddNews(news);
            NewsList = _dataService.GetNews();
            return RedirectToPage();
        }

       
        public IActionResult OnGetEditNews(string id)
        {
            
            NewsList = _dataService.GetNews();
            News = NewsList.FirstOrDefault(n => id.Equals(n.RowKey));
            return Page();
        }
        public IActionResult OnGetAddNewNews(string id)
        {

            NewsList = _dataService.GetNews();
            return RedirectToPage();
        }

        public IActionResult OnGetDeleteNews(string id)
        {

            NewsList = _dataService.GetNews();
            News = NewsList.FirstOrDefault(n => id.Equals(n.RowKey));
            _dataService.DeleteNews(News);
            return RedirectToPage();
        }
    }
}
