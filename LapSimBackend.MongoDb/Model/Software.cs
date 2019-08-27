using LapSimBackend.Data.Interfaces;

namespace LapSimBackend.MongoDb.Model
{
    public class Software : ISoftware
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
