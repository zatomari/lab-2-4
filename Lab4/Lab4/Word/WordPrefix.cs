namespace Lab4.Word;

using System.Text;

// Класс приставки
public class WordPrefix : WordPart {
    public WordPrefix() : base() {}

    public WordPrefix(string prefix) : base(prefix) {}

    public WordPrefix(string[] prefixes) : base(prefixes) {}

    // приставка1-приставка2-
    public override string Output() {
        // префикса нет
        if (part.Length == 0) {
            return "";
        }

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < part.Length; i++) {
            if (part[i] != "") {
                stringBuilder.Append(part[i]);
                stringBuilder.Append('-');
            }
        }

        return stringBuilder.ToString();
    }
}