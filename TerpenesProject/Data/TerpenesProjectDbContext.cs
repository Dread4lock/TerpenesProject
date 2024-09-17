using Microsoft.EntityFrameworkCore;
using TerpenesProject.Models;

public class TerpenesProjectDbContext : DbContext
{
    public TerpenesProjectDbContext(DbContextOptions<TerpenesProjectDbContext> options)
        : base(options)
    {
    }

    // Таблицы в базе данных
    public DbSet<Terpene> Terpenes { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<TerpeneCondition> TerpeneConditions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка промежуточной таблицы
        modelBuilder.Entity<TerpeneCondition>()
            .HasKey(tc => new { tc.TerpeneId, tc.ConditionId }); // Композитный ключ

        modelBuilder.Entity<TerpeneCondition>()
            .HasOne(tc => tc.Terpene)
            .WithMany(t => t.TerpeneConditions)
            .HasForeignKey(tc => tc.TerpeneId);

        modelBuilder.Entity<TerpeneCondition>()
            .HasOne(tc => tc.Condition)
            .WithMany(c => c.TerpeneConditions)
            .HasForeignKey(tc => tc.ConditionId);
    }
}
