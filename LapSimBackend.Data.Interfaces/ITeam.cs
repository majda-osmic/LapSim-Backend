using LapSimBackend.Data.Interfaces.Imlementations;
using System.Collections.Generic;

namespace LapSimBackend.Data.Interfaces
{
    public interface ITeam
    {
        string Id { get; set; }
        string Name { get; set; }
        IEnumerable<IAccount> Accounts { get; set; }
        int Budget { get; set; }
        int UsedBudget { get; set; }
    }
}