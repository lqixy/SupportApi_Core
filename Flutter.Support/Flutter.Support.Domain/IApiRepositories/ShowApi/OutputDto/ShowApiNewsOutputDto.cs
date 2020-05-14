using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.ShowApi.OutputDto
{
    public class ShowApiNewsOutputDto : ShowApiOutputBodyBase
    {
        public int Ret_Code { get; set; }

        public ShowApiNewsPagerOutputDto PageBean { get; set; }
    }

    public class ShowApiNewsPagerOutputDto
    {
        public int AllPages { get; set; }

        public List<ShowApiNewsDetailOutputDto> ContentList { get; set; }
    }

    public class ShowApiNewsDetailOutputDto
    {
        public string Id { get; set; }

        public bool HavePic { get; set; }

        public DateTime PubDate { get; set; }

        public string Title { get; set; }

        public string ChannelName { get; set; }

        public string Source { get; set; }

        public string ChannelId { get; set; }

        public string Link { get; set; }

        public string Image { get; set; }

        public List<ShowApiNewsImageOutputDto> ImageUrls { get; set; }
    }

    public class ShowApiNewsImageOutputDto
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public string Url { get; set; }
    }
}
