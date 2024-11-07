namespace Lab2.Word;

// Класс окончания
public class WordEnding : WordPart {

    public WordEnding() : base() {}
    public WordEnding(string end) : base(end) {}

    // -окончание
    public override string Output() {
        // окончания нет
        if (part.Length == 0) {
            return "";
        }

        return !string.IsNullOrEmpty(part[0]) ? "-" + part[0] : "";
    }
}