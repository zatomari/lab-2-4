namespace Lab2.Vocabulary;

using Lab2.Word;
using Microsoft.EntityFrameworkCore;

// Класс менеджера словаря, загружает и сохраняет словарь
public class VocabularyManager {
    private const string dbName = "Dictionary.db";

    public static async Task Read(Vocabulary vcb) {
        VocabularyContext context = new VocabularyContext(dbName);

        context.Database.EnsureCreated();

        var words = await context.Words.ToListAsync();

        foreach (var wordDb in words) {
            vcb.AddWord(new Word(
                new WordPrefix(WordPart.Deserialize(wordDb.Prefix)),
                new WordRoot(wordDb.Root),
                new WordSuffix(WordPart.Deserialize(wordDb.Suffix)),
                new WordEnding(wordDb.Ending)
            ));
        }
    }

    public static async Task Write(Vocabulary vcb) {
        VocabularyContext context = new VocabularyContext(dbName);

        using (var transaction = await context.Database.BeginTransactionAsync()) {
            try {
                foreach (List<Word> words in vcb.root2Words.GetDictionary().Values) {
                    foreach (Word word in words) {
                        WordDb wordDb = word.Serialize();
                        var existingWord = await context.Words.FirstOrDefaultAsync(w => w.Id == wordDb.Id);

                        if (existingWord != null) {
                            context.Entry(existingWord).CurrentValues.SetValues(wordDb);
                        } else {
                            await context.Words.AddAsync(wordDb);
                        }
                    }
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
