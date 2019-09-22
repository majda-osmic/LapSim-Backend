using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class Team : ITeam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public int UsedBudget { get; set; }
        public IEnumerable<IAccountDetail> Accounts { get; set; }

    }
}
