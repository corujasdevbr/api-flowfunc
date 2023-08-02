using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Corujasdev.Flowfunc.Domain.Entities;

namespace Corujasdev.Flowfunc.Persistence.Mappings;

public class RuleMap : IEntityTypeConfiguration<Rule>
{
    public void Configure(EntityTypeBuilder<Rule> builder)
    {
        builder.ToTable("Rules");
        builder.HasKey(c => c.Id);
        builder.Property(d => d.FunctionName).HasColumnType("VARCHAR(32)").IsRequired();
        builder.Property(d => d.Description).HasColumnType("TEXT").IsRequired();
        builder.Property(d => d.RuleType).HasColumnType("VARCHAR(10)");
        builder.Property(x => x.DateCreated).HasColumnType("DATETIME").IsRequired();
        builder.Property(x => x.DateUpdated).HasColumnType("DATETIME");
        builder.Property(x => x.DateDeleted).HasColumnType("DATETIME");
    }
}