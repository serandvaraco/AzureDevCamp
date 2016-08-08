using Blueyonder.Entities;
using System.Data.Entity;

namespace Blueyonder.DataAccess
{
    public class FrequentFlyersContext : DbContext
    {
        public FrequentFlyersContext(string connectionName) : base(connectionName)
        {
        }

        public FrequentFlyersContext() : base("BlueYonderFrequentFlyer")
        {
        }

        public DbSet<FrequentFlyer> FrequentFlyers { get; set; }
    }
}
