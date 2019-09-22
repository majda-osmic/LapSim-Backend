
namespace LapSimBackend.Data.Interfaces.Imlementations
{
    public class Account : IAccountDetail
    {
        public int CPUs { get; set; }
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public ISoftwarePackage Package { get; set; }

        public Account(){}

        public Account(IAccountInfo info)
        {
            CPUs = info.CPUs;
            Name = info.Name;
            UniqueName = info.UniqueName;
        }
    }
}
