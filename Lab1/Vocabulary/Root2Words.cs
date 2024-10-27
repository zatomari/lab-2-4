namespace Lab1.Vocabulary;

using Lab1.Word;

// Класс словарь вида корень-список слов
public class Root2Words {
    private Dictionary<string, List<Word>> root2Words;

    public Root2Words() {
        root2Words = new Dictionary<string, List<Word>>();
    }

    public Word[] GetWords(string root) {
        if (!root2Words.ContainsKey(root)) {
            return Array.Empty<Word>();
        }
        return root2Words[root].ToArray();
    }

    public void AddWord(Word word) {
        List<Word> words;
        string root = word.GetRoot().ToString();

        if (root2Words.ContainsKey(root)) {
            words = root2Words[root];
        } else {
            words = new List<Word>();
            root2Words[root] = words;
        }

        words.Add(word);
    }

    public Dictionary<string, List<Word>> GetDictionary() {
        return root2Words;
    }
}
