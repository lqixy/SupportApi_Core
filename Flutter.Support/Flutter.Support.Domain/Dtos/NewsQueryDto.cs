using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.Dtos
{
    public class NewsQueryDto
    {
        public int TotalCount { get; set; }

        public IEnumerable<NewsInfoQueryDto> List { get; set; }
    }

    public class NewsInfoQueryDto
    {
        public string UniqueKey { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public string AuthorName { get; set; }

        public string Url { get; set; }

        //public IEnumerable<string> ImageUrls { get; set; }
        public string JsonData { get; set; }

        public int Type { get; set; }
    }
}
