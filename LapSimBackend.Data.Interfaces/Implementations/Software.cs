using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class Software : ISoftware
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
