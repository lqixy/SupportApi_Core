using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.AutoService.Services
{
    public interface IAutoService
    {
        string ServiceName { get; }

        void Start();

        bool IsEnable { get; }
    }
}
