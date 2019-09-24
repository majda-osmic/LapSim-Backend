using LapSimBackend.Data.Interfaces;
using System.Collections.Generic;

namespace LapSimBackend.Service.Interfaces
{
    public interface IProjectLeadersService
    {
        IEnumerable<IProjectLeader> Get();
        bool Exists(string userName);
        IProjectLeader Get(string userName);
        bool UserManagesAccount(string userName, string accountId);
        void Delete(string userName);
    }
}
