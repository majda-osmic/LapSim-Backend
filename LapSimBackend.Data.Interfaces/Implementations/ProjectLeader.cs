using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class ProjectLeader : IProjectLeader
    {
        public string UserName { get; set; }
        public IEnumerable<string> Teams { get; set; }
    }
}
