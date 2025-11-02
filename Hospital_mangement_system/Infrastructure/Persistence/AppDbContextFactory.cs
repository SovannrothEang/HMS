using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hospital_mangement_system.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionBuilder.UseSqlServer("""
        
            Data Source=localhost\MSSQLSERVER2022;
            Initial Catalog=hms;
            Integrated Security=True;
            Persist Security Info=False;
            Pooling=False;
            MultipleActiveResultSets=False;
            Encrypt=False;
            TrustServerCertificate=False
            
            """);

        return new AppDbContext(optionBuilder.Options);
    }
}
