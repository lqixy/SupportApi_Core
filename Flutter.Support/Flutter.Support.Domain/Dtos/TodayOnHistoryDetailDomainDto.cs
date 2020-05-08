using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.Dtos
{
    public class TodayOnHistoryDetailDomainDto
    {
        public TodayOnHistoryDetailDomainDto() { }
        public TodayOnHistoryDetailDomainDto(int id,string title,string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
