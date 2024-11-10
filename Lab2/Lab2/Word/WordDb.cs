namespace Lab2.Word;

using System.ComponentModel.DataAnnotations;

// Класс модели для маппинга между записями базы данных и объектов Word
public class WordDb {
    [Key]
    public string Id { get; private set; }
    public string Prefix { get; private set; }
    public string Root { get; private set; }
    public string Suffix { get; private set; }
    public string Ending { get; private set; }

    public WordDb(string prefix, String root, String suffix, String ending) {
        // Id -- собранное полностью слово
        Id = prefix.Replace(",", "") + root + suffix.Replace(",", "") + ending;

        Prefix = prefix;
        Root = root;
        Suffix = suffix;
        Ending = ending;
    }
}
