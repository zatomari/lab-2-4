namespace Lab2.Vocabulary;

using Lab2.Word;
using Microsoft.EntityFrameworkCore;

// Класс словаря
public class Vocabulary {
    private VocabularyContext context;

    // isClean = true, если нужно создать словарь с пустой базой (нужно для тестов)
    public Vocabulary(string dbName, bool isClean = false) {
        context = new VocabularyContext(dbName);

        if (isClean) {
            context.Database.EnsureDeleted();
        }

        context.Database.EnsureCreated();
    }

    // есть ли слово в словаре
    public async Task<bool> Has(string word) {
        return await context.Words.FirstOrDefaultAsync(w => w.Id == word) != null;
    }

    // Возвращает массив слов(объектов) с корнем root
    public async Task<Word[]> GetWords(string root) {
        var words = await context.Words.Where(w => w.Root == root).ToListAsync();
        List<Word> result = new List<Word>();
        foreach (var wordDb in words) {
            result.Add(new Word(
                new WordPrefix(WordPart.Deserialize(wordDb.Prefix)),
                new WordRoot(wordDb.Root),
                new WordSuffix(WordPart.Deserialize(wordDb.Suffix)),
                new WordEnding(wordDb.Ending)
            ));
        }

        return result.ToArray();
    }

    // Добавить слово в словарь
    public async void AddWord(Word word) {
        WordDb wordDb = word.Serialize();
        var existingWord = await context.Words.FirstOrDefaultAsync(w => w.Id == wordDb.Id);

        if (existingWord != null) {
            return;
        }

        using (var transaction = await context.Database.BeginTransactionAsync()) {
            try {
                await context.Words.AddAsync(wordDb);

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    // Метод получения корня у переданного слова
    public async Task<string> GetRoot(string word) {
        var existingWord = await context.Words.FirstOrDefaultAsync(w => w.Id == word);

        if (existingWord == null) {
            return "";
        }

        return existingWord.Root;
    }

    // Метод получения списка однокоренных слов по переданному слово words
    public async Task<Word[]> GetKnownWords(String word) {
        Word[] words = await GetWords(await GetRoot(word));

        Array.Sort(words);

        return words;
    }
}
