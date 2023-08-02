using Corujasdev.Flowfunc.Domain.Entities;
using Corujasdev.Flowfunc.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Corujasdev.Flowfunc.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext()
    {
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Rule> Rules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RuleMap());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-T4MFJEU;Initial Catalog=Db_FlowFunc_Dev;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}