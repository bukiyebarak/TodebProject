using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DAL.DbContexts
{
    public class TodebDbContext:DbContext
    {
        private IConfiguration _configuration;
        public TodebDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       public DbSet<Order> Orders { get; set; }
       
        public DbSet<User> Users { get; set; }
        
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }





        //Tabloları veritabanına kaydetmek
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-3290BLE;Database=TodebProject;Trusted_Connection=True"));

            var connectionString = _configuration.GetConnectionString("MsComm");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
