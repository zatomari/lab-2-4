namespace Lab4.Word;

using System.Text;

// Класс слова
public class Word : IComparable<Word> {
    private static readonly string PARTS_DELIMITER = ";";

    protected WordPrefix prefix;
    protected WordSuffix suffix;
    protected WordRoot root;
    protected WordEnding ending;

    public Word(WordPrefix prefix, WordRoot root, WordSuffix suffix, WordEnding ending) {
        this.prefix = prefix;
        this.root = root;
        this.suffix = suffix;
        this.ending = ending;
    }

    // приставка1-приставка2-корень-суффикс1-суффикс2-окончание
    public string Output() {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(prefix.Output());
        stringBuilder.Append(root.Output());
        stringBuilder.Append(suffix.Output());
        stringBuilder.Append(ending.Output());

        return stringBuilder.ToString();
    }

    // Преобразование объекта слова в слово в формате БД
    public WordDb SerializeToWordDb() {
        return new WordDb(
            prefix.Serialize(), // приставка1,приставка2
            root.Serialize(),   // корень
            suffix.Serialize(), // суффикс1,суффикс2
            ending.Serialize()  // окончание
        );
    }

    public string Serialize() {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(prefix.Serialize()); // приставка1,приставка2
        stringBuilder.Append(PARTS_DELIMITER);
        stringBuilder.Append(root.Serialize()); // корень
        stringBuilder.Append(PARTS_DELIMITER);
        stringBuilder.Append(suffix.Serialize()); // суффикс1,суффикс2
        stringBuilder.Append(PARTS_DELIMITER);
        stringBuilder.Append(ending.Serialize()); // окончание

        return stringBuilder.ToString();
    }

    public static Word Deserialize(string input) {
        string[] parts = input.Split(PARTS_DELIMITER);

        return new Word(
            new WordPrefix(WordPart.Deserialize(parts[0])),
            new WordRoot(parts[1]),
            new WordSuffix(WordPart.Deserialize(parts[2])),
            new WordEnding(parts[3])
        );
    }

    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(prefix.ToString());
        stringBuilder.Append(root.ToString());
        stringBuilder.Append(suffix.ToString());
        stringBuilder.Append(ending.ToString());

        return stringBuilder.ToString();
    }

    public int CompareTo(Word? o) {
            if (o is null)
                throw new ArgumentException("Некорректное значение параметра");

            int result = prefix.GetPart().Length - o.prefix.GetPart().Length;

            if (result == 0) {
                result = suffix.GetPart().Length - o.suffix.GetPart().Length;

                if (result == 0) {
                    result = ending.GetPart().Length - o.ending.GetPart().Length;
                }
            }

            return result;
    }
}
