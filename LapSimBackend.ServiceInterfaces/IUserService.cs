using LapSimBackend.Data.Interfaces;

namespace LapSimBackend.Service.Interfaces
{
    public interface IUserService
    {
        bool Authenticate(string userName, string password);
        IUser Create(string userName, string password);
    }
}
