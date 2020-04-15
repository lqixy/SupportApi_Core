using Flutter.Support.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Domain.IRepositories
{
    public interface INewsRepository
    {
        Task TryInsertRecordAsync(News model);
    }
}
