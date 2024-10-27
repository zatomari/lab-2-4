namespace Lab1.Vocabulary;

using Lab1.Word;

// Класс словаря
// solid - s ?
public class Vocabulary {
    // Dictionary слово-корень
    private Word2Root word2Root;

    // Dictionary корень-список слов
    private Root2Words root2Words;

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

// *
    public async Task ReadFromFile(string fileName) {
        using (StreamReader reader = new StreamReader(fileName)) {
            while (!reader.EndOfStream) {
                String? line = await reader.ReadLineAsync();
                if (line == null) continue;

                string[] parts = line.Split(';');
                if (parts.Length == 4) {
                    AddWord(new Word(
                        new WordPrefix(parts[0] == "" ? Array.Empty<string>() : parts[0].Split(',')),
                        new WordRoot(parts[1]),
                        new WordSuffix(parts[2] == "" ? Array.Empty<string>() : parts[2].Split(',')),
                        new WordEnding(parts[3])
                    ));
                }
            }
        }
    }

    // *  (а так же подумать почему нужно минимум 2 интерфейса в этом замечательном приложении)
    public async Task SaveToFile(string fileName) {
        using (StreamWriter writer = new StreamWriter(fileName)) {
            foreach (List<Word> words in root2Words.GetDictionary().Values) {
                foreach (Word word in words) {
                    await writer.WriteLineAsync(word.Serialize());
                }
            }
        }
    }

    public IReadOnlyCollection<Word> OutputKnownWords(String input) {
        Word[] words = GetWords(GetRoot(input));

        Array.Sort(words);

       /* foreach (Word word in words){
            Console.WriteLine(word.Output());
        }*/
        return words;
    }
}

// * смотри строчку 2
