using System.Text;

// Абстрактный класс словообразующей части.
// Каждая часть слова может быть одна (корень, окончание),
// или несколько (приставки, суффиксы).
// Части слова одного типа хранятся в массиве part

public abstract class WordPart {

    protected string[] part;

    public WordPart(){
        this.part = new string[0];
    }

    public WordPart(string part){
        this.part = new string[1];
        this.part[0] = part;
    }

    public WordPart(string[] part){
        this.part = part;
    }

    // метод перевода частей слова в строку для записи в файл
    public string Serialize(){
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < part.Length; i++){
            if (i != 0){
                stringBuilder.Append(",");
            }
            stringBuilder.Append(part[i]);
        }
        return stringBuilder.ToString();
    }

    public string[] GetPart(){
        return this.part;
    }

    public string ToString(){
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < part.Length; i++){
            stringBuilder.Append(part[i]);
        }
        return stringBuilder.ToString();
    }

    public abstract string Output();
}