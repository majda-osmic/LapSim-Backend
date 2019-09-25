using Newtonsoft.Json;

namespace LapSimBackend.Data.Interfaces
{
    public interface IAccount
    {
        string Id { get; set; }

        string Name { get; set; }

        int CPUs { get; set; }

        ISoftwarePackage SoftwarePacakge { get; set; }

    }
}