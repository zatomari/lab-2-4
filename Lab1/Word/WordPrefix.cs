namespace Lab1.Word;

using System.Text;

// Класс приставки
public class WordPrefix : WordPart {
    public WordPrefix() : base() {}

    public WordPrefix(string prefix) : base(prefix) {}

    public WordPrefix(string[] prefixes) : base(prefixes) {}

    // приставка1-приставка2-
    public override string Output() {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < part.Length; i++) {
            stringBuilder.Append(part[i]);
            stringBuilder.Append('-');
        }

        return stringBuilder.ToString();
    }
}