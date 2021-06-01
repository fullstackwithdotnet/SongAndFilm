using Microsoft.Extensions.Configuration;
using SongAndFilm.Core;
using SongAndFilm.Core.Models;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using System.Linq;
using System;

namespace SongAndFilm.Persistance
{
    public class AzureDataService : IAzureDataService
    {
        private readonly IConfiguration Configuration;
        private readonly string accountName;
        private readonly string accountKey;
        private readonly CloudTable tblNews;

        public AzureDataService(IConfiguration configuration)
        {
            Configuration = configuration;
            accountName = Configuration["Azure:AccountName"];
            accountKey = Configuration["Azure:AccountKey"];
            StorageCredentials cred = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount csa = new CloudStorageAccount(cred, true);
            CloudTableClient client = csa.CreateCloudTableClient();
            tblNews = client.GetTableReference("SnFNews");

        }

       

        public List<News> GetNews()
        {             
            string queryString = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "News");
            TableQuery<News> q = new TableQuery<News>().Where(queryString);
            return tblNews.ExecuteQuery(q).ToList();
        }
        public void AddNews(News news)
        {
            News n;
            if (news.RowKey == null)
            {
               n = new News("News", Guid.NewGuid().ToString())
                {
                    Title = news.Title,//"The Little Things",
                    Content = news.Content,
                    ImageUrl = news.ImageUrl,
                    IFrameEmbed = news.IFrameEmbed
                };
            }
            else
            {
                n = news;
            }

            
            TableOperation tblIns = TableOperation.InsertOrMerge(n);
            TableResult rslt = tblNews.Execute(tblIns);            
        }

        public void DeleteNews(News news)
        {
            TableOperation tblIns = TableOperation.Delete(news);
            TableResult rslt = tblNews.Execute(tblIns);
        }
    }
}
