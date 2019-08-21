using System;

namespace LapSimBackend.Data.Interfaces
{
    public interface ISimulation
    {
        string AccountId { get; set; }
        int CPUs { get; set; }
        DateTime EndTime { get; set; }
        string Id { get; set; }
        string Location { get; set; }
        string Name { get; set; }
        int Runs { get; set; }
        DateTime StartTime { get; set; }
        int UsedBudget { get; set; }
    }
}