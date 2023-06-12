using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Sheenam.Api.Brokers.Storages
{
    public class StorageBroker : EFxceptionsContext
    {
        public IConfiguration Configuration;

        public StorageBroker(IConfiguration configuration)
        {
            Configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectString = 
                this.Configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectString);
        }

        public override void Dispose() {}
    }
}
