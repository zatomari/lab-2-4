namespace Lab1.Word;

// Класс корня
public class WordRoot : WordPart {
    public WordRoot(string root) : base(root) {}

    public override string Output() {
        return part[0];
    }
}