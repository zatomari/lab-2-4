namespace Lab2.Vocabulary;

using Lab2.Word;
using Microsoft.EntityFrameworkCore;

public class VocabularyContext : DbContext {
    private String dbName;

    public VocabularyContext(String dbName) : base() {
        this.dbName = dbName;
    }

    public virtual DbSet<WordDb> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=" + dbName);
    }
}
