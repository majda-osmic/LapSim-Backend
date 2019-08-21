using System.Collections.Generic;

namespace LapSimBackend.Data.Interfaces
{
    public interface IProjectLeader
    {
        string UserName { get; set; }
        IEnumerable<string> Teams { get; set; }
    }
}