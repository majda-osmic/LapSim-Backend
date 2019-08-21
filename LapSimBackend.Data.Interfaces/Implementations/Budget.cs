using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class Budget : IBudget
    {
        public DateTime Expires { get; set; }
        public DateTime Ordered { get; set; }
        public int Units { get; set; }
    }
}
