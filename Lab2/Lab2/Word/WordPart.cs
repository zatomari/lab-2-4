namespace Lab2.Word;

using System.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;

// Абстрактный класс словообразующей части.
// Каждая часть слова может быть одна (корень, окончание),
// или несколько (приставки, суффиксы).
// Части слова одного типа хранятся в массиве part
public abstract class WordPart {
    private static readonly string PARTS_DELIMITER = ",";

    protected string[] part;

    public WordPart() {
        part = Array.Empty<string>();
    }

    public WordPart(string part) {
        this.part = new string[1];
        this.part[0] = part;
    }

    public WordPart(string[] part) {
        this.part = part;
    }

    // метод перевода частей слова в строку для записи в БД
    public string Serialize() {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < part.Length; i++) {
            if (i != 0) {
                stringBuilder.Append(PARTS_DELIMITER);
            }
            stringBuilder.Append(part[i]);
        }
        return stringBuilder.ToString();
    }

    public static string[] Deserialize(string input) {
        return input.Split(PARTS_DELIMITER);
    }

    public string[] GetPart() {
        return part;
    }

    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < part.Length; i++) {
            stringBuilder.Append(part[i]);
        }

        return stringBuilder.ToString();
    }

    public abstract string Output();
}