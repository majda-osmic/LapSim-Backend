using LapSimBackend.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.DataModels
{
    public class Software : ISoftware
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
