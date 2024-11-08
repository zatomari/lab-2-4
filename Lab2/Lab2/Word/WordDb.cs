namespace Lab2.Word;

using System.ComponentModel.DataAnnotations;

// Класс слова
public class WordDb {
    [Key]
    public string Id { get; private set; }
    public string Prefix { get; private set; }
    public string Root { get; private set; }
    public string Suffix { get; private set; }
    public string Ending { get; private set; }

    public WordDb(string prefix, String root, String suffix, String ending) {
        Prefix = prefix;
        Root = root;
        Suffix = suffix;
        Ending = ending;
        Id = prefix + root + suffix + ending;
    }
}
