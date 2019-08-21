using System;
using System.Collections.Generic;

namespace LapSimBackend.Data.Interfaces
{
    public interface ISoftwarePackage
    {
        IEnumerable<ISoftware> Software { get; set; }
        DateTime TimeStamp { get; set; }
    }
}