// Класс окончания
public class WordEnding : WordPart {

    public WordEnding() : base() {}
    public WordEnding(string end) : base(end) {}

    // -окончание
    public override string Output() {
        return !string.IsNullOrEmpty(part[0]) ? "-" + part[0] : "";
    }
}