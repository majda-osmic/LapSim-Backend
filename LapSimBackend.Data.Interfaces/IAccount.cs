using Newtonsoft.Json;

namespace LapSimBackend.Data.Interfaces
{
    public interface IAccount
    {
        [JsonProperty(PropertyName = "id")]
        string UniqueName { get; set; }

        [JsonProperty(PropertyName = "name")]
        string Name { get; set; }

        [JsonProperty(PropertyName = "cpus")]
        int CPUs { get; set; }

        //ISoftwarePackage Package { get; set; }
    }
}