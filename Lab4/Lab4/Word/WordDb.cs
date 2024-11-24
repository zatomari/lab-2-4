namespace Lab4.Word;

using System.ComponentModel.DataAnnotations;

// Класс модели для маппинга между записями базы данных и объектов Word
public class WordDb {
    [Key]
    public string Id { get; set; }
    public string Prefix { get; set; }
    public string Root { get; set; }
    public string Suffix { get; set; }
    public string Ending { get; set; }

    public WordDb(string prefix, String root, String suffix, String ending) {
        // Id -- собранное полностью слово
        Id = prefix.Replace(",", "") + root + suffix.Replace(",", "") + ending;

        Prefix = prefix;
        Root = root;
        Suffix = suffix;
        Ending = ending;
    }
}
