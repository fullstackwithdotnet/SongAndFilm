using SongAndFilm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAndFilm.Core
{
    public interface IAzureDataService
    {
        public List<News> GetNews();
        public void AddNews(News news);
        public void DeleteNews(News news);
    }
}
