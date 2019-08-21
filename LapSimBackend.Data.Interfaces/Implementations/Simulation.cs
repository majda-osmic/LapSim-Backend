using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class Simulation : ISimulation
    {
        public string AccountId { get; set; }
        public int CPUs { get; set; }
        public DateTime EndTime { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public int Runs { get; set; }
        public DateTime StartTime { get; set; }
        public int UsedBudget { get; set; }
    }
}
