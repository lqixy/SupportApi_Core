using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Application.News.Dtos
{
    public class NewsQueryDto
    {
        public int TotalCount { get; set; }

        public IEnumerable<NewsInfoDto> News { get; set; }
    }

    public class NewsInfoDto
    {
        public string UniqueKey { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public string AuthorName { get; set; }

        public string Url { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }


    }
}
