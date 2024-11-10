namespace Lab2.Vocabulary;

using Lab2.Word;
using Microsoft.EntityFrameworkCore;

// Класс взаимодейтсвия словаря с базой данных
public class VocabularyContext : DbContext {
    private String dbName;

    public VocabularyContext(String dbName) : base() {
        this.dbName = dbName;
    }

    // Возвращает список слов из базы данных
    public virtual DbSet<WordDb> Words { get; set; }

    // Конфигурация подключения к БД
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=" + dbName);
    }
}
