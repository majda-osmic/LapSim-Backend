using Newtonsoft.Json;

namespace LapSimBackend.Data.Interfaces
{
    public interface IAccountInfo
    {
        [JsonProperty(PropertyName = "id")]
        string UniqueName { get; set; }

        [JsonProperty(PropertyName = "name")]
        string Name { get; set; }

        [JsonProperty(PropertyName = "cpus")]
        int CPUs { get; set; }


    }

    public interface IAccountDetail : IAccountInfo
    {
        [JsonProperty(PropertyName = "softwarePackage")]
        ISoftwarePackage Package { get; set; }
    }
}