using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RankingSystem.RankingSystem.Models;

namespace RankingSystem.RankingSystem;

public sealed class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        Database.Migrate();
    }
    public DbSet<TowerRankingModel> Scores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = @".\\Database\\ranking.db"
        }.ToString();
        
        optionsBuilder.UseSqlite(new SqliteConnection(connectionString));
    }
    
}