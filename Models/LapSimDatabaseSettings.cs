﻿namespace LapSimBackend.Models
{
    public interface ILapSimDatabaseSettings
    {
        string TeamsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class LapSimDatabaseSettings : ILapSimDatabaseSettings
    {
        public string TeamsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}