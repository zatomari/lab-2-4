namespace Lab1.Word;

using System.Text;

// Класс суффикса
public class WordSuffix : WordPart {
    public WordSuffix() : base() {}

    public WordSuffix(string suffix) : base(suffix) {}

    public WordSuffix(string[] suffixes) : base(suffixes) {}

    // -суффикс1-суффикс2
    public override string Output() {
        // суффикса нет
        if(part.Length == 0) {
            return "";
        }

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < part.Length; i++) {
            if (part[i] != "") {
                stringBuilder.Append('-');
                stringBuilder.Append(part[i]);
            }
        }

        return stringBuilder.ToString();
    }
}
