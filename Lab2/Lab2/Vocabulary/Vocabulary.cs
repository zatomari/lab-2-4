namespace Lab2.Vocabulary;

using Lab2.Word;

// Класс словаря
public class Vocabulary {
    // Dictionary слово-корень
    internal Word2Root word2Root;

    // Dictionary корень-список слов
    internal Root2Words root2Words;

    public Vocabulary() {
        word2Root = new Word2Root();
        root2Words = new Root2Words();
    }

    // есть ли слово в словаре
    public bool Has(string word) {
        return word2Root.Has(word);
    }

    public Word[] GetWords(string root) {
        return root2Words.GetWords(root);
    }

    public void AddWord(Word word) {
        root2Words.AddWord(word);
        word2Root.AddWord(word);
    }

    public string GetRoot(string word) {
        return word2Root.GetRoot(word);
    }

    public IReadOnlyCollection<Word> GetKnownWords(String root) {
        Word[] words = GetWords(GetRoot(root));

        Array.Sort(words);

        return words;
    }
}
