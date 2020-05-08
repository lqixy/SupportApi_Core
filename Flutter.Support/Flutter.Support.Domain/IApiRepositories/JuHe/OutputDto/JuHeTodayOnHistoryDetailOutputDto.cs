using Flutter.Support.Extension.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto
{
    public class JuHeTodayOnHistoryDetailOutputDto : JuHeApiResultBaseDto, IApiResultDto
    {
        public List<JuHeTodayOnHistoryDetailInfoOutputDto> Result { get; set; }

    }

    public class JuHeTodayOnHistoryDetailInfoOutputDto
    {
        public int E_Id { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        //public string PicUrl { get; set; }
    }
}
