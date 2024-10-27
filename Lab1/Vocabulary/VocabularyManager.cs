namespace Lab1.Vocabulary;

using Lab1.Word;

// Класс менеджера словаря, загружает и сохраняет словарь в файл
public class VocabularyManager {
    public static async Task ReadVocabularyFromFile(Vocabulary vcb, string fileName) {
        using (StreamReader reader = new StreamReader(fileName)) {
            while (!reader.EndOfStream) {
                String? line = await reader.ReadLineAsync();
                if (line == null) continue;

                string[] parts = line.Split(';');
                if (parts.Length == 4) {
                    vcb.AddWord(new Word(
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
    public static async Task SaveVocabularyToFile(Vocabulary vcb, string fileName) {
        using (StreamWriter writer = new StreamWriter(fileName)) {
            foreach (List<Word> words in vcb.root2Words.GetDictionary().Values) {
                foreach (Word word in words) {
                    await writer.WriteLineAsync(word.Serialize());
                }
            }
        }
    }
}
