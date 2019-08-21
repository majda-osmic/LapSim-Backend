using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class SoftwarePacakge : ISoftwarePackage
    {
        public IEnumerable<ISoftware> Software { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
