using Microsoft.Azure.Cosmos.Table;
using System;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Type")]
        public string NewsType  { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string IFrameEmbed { get; set; }
    }
}
