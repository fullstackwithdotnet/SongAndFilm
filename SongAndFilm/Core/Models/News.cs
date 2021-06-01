using Microsoft.Azure.Cosmos.Table;
using System;

namespace SongAndFilm.Core.Models
{
    public class News: TableEntity
    {
        public News() { }
        public News(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

       
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string IFrameEmbed { get; set; }
    }
}
