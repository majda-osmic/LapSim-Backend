namespace LapSimBackend.Data.Interfaces
{
    public interface IAccount
    {
        int CPUs { get; set; }
        string Name { get; set; }
        string UniqueName { get; set; }
    }
}