namespace LapSimBackend.DataModels
{
    public interface ILapSimDatabaseSettings
    {
        string TeamsCollectionName { get; set; }
        string ProjectLeadersCollectionName { get; set; }
        string SimulationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class LapSimDatabaseSettings : ILapSimDatabaseSettings
    {
        public string TeamsCollectionName { get; set; }
        public string ProjectLeadersCollectionName { get; set; }
        public string SimulationsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
