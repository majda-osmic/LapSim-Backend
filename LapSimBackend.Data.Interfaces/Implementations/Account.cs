﻿
namespace LapSimBackend.Data.Interfaces.Imlementations
{
    public class Account : IAccount
    {
        public int CPUs { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public ISoftwarePackage SoftwarePacakge { get; set; }

    }
}
