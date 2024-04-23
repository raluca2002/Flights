using Microsoft.EntityFrameworkCore;
using MPP_Csharp_Server_Client.FlightModel.domain;

namespace FlightPersistenceORM;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    } 
    public DbSet<User> user { get; set; }
    public DbSet<Zbor> zbor { get; set; }
    public DbSet<Bilet> bilet { get; set; }
    //public DbSet<BiletTurist> bilet_turisti { get; set; }

}