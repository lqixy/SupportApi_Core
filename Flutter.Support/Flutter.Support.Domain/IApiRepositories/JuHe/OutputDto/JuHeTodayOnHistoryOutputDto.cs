using Flutter.Support.Extension.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto
{
    public class JuHeTodayOnHistoryOutputDto : JuHeApiResultBaseDto, IApiResultDto
    {
        public List<JuHeTodayOnHistoryInfoOutputDto> Result { get; set; }
    }

    public class JuHeTodayOnHistoryInfoOutputDto
    {
        public string Day { get; set; }

        public string Date { get; set; }

        public string Title { get; set; }

        public int E_Id { get; set; }

    }
}
