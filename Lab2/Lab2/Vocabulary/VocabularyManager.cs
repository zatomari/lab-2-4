namespace Lab2.Vocabulary;

using Lab2.Word;

// Класс менеджера словаря, загружает и сохраняет словарь в файл
public class VocabularyManager {
    public static async Task Read(Vocabulary vcb, TextReader reader) {
        String? line;

        using (reader) {
            while ((line = await reader.ReadLineAsync()) != null) {
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

    public static async Task Write(Vocabulary vcb, TextWriter writer) {
        using (writer) {
            foreach (List<Word> words in vcb.root2Words.GetDictionary().Values) {
                foreach (Word word in words) {
                    await writer.WriteLineAsync(word.Serialize());
                }
            }
        }
    }
}
