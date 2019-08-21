using System;

namespace LapSimBackend.Data.Interfaces
{
    public interface IBudget
    {
        DateTime Expires { get; set; }
        DateTime Ordered { get; set; }
        int Units { get; set; }
    }
}