// Класс словарь вида слово-корень
public class Word2Root{
    private Dictionary<string, string> word2Root;

    public Word2Root() {
        word2Root = new Dictionary<string, string>();
    }

    public bool Has(string word) {
        return word2Root.ContainsKey(word);
    }

    public void AddWord(Word word) {
        string root = word.GetRoot().ToString();
        word2Root [word.ToString()] = root;
    }

    public string GetRoot(string word) {
        return word2Root[word];
    }
}
