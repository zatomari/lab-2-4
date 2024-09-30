// Класс словаря
public class Vocabulary{

    // Dictionary слово-корень
    private Word2Root word2Root;

    // Dictionary корень-список слов
    private Root2Words root2Words;

    public Vocabulary (){
        word2Root = new Word2Root();
        root2Words = new Root2Words();
    }

    // есть ли слово в словаре
    public bool Has(string word){
        return word2Root.Has(word);
    }

    public Word[] GetWords(string root){
        return root2Words.GetWords(root);
    }

    public void AddWord(Word word){
        root2Words.AddWord(word);
        word2Root.AddWord(word);
    }

    public string GetRoot(string word){
        return word2Root.GetRoot(word);
    }
    public static Vocabulary ReadFromFile(string fileName)
    {
        Vocabulary result = new Vocabulary();
        try
        {
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split(';');
                    result.AddWord(new Word(
                        new WordPrefix(parts[0] == "" ? new string[0] : parts[0].Split(',')),
                        new WordRoot(parts[1]),
                        new WordSuffix(parts[2] == "" ? new string[0] : parts[2].Split(',')),
                        new WordEnding(parts[3])
                    ));
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to read from file " + fileName);
        }

        return result;
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(root2Words.Serialize() );
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to save to file " + fileName);
        }
    }
}
