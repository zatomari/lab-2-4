using System.Text;

// Класс слова
public class Word : IComparable<Word> {
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

    public WordRoot GetRoot() {
        return root;
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

    // приставка1,приставка2;корень;суффикс1,суффкс2;окончание
    public string Serialize() {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(prefix.Serialize());
        stringBuilder.Append(';');
        stringBuilder.Append(root.Serialize());
        stringBuilder.Append(';');
        stringBuilder.Append(suffix.Serialize());
        stringBuilder.Append(';');
        stringBuilder.Append(ending.Serialize());

        return stringBuilder.ToString();
    }

    public override string ToString(){
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
