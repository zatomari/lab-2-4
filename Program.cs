public class Program{
    public static void Main(string[] args){

        string fileName = "Dictionary.csv";
        Vocabulary vcb = Vocabulary.ReadFromFile(fileName);

        Word[] words;

        Console.WriteLine("----------------------------");
        if (vcb.Has("думать"))
        {
            Console.WriteLine("Слово 'думать' есть в словаре");
        }

        if (!vcb.Has("спать"))
        {
            Console.WriteLine("Слово 'спать' нет в словаре");
        }

        Console.WriteLine("----------------------------");
        Console.WriteLine("Все слова к корнем 'дум':");
        Console.WriteLine();

        words = vcb.GetWords("дум");
        Array.Sort(words);
        foreach (Word word in words)
        {
            Console.WriteLine(word.Output());
        }
        Console.WriteLine("----------------------------");

        Console.WriteLine("Все слова к корнем 'спать':");
        Console.WriteLine();

        words = vcb.GetWords("спать");
        foreach (Word word in words)
        {
            Console.WriteLine(word.Output());
        }
        Console.WriteLine("----------------------------");

        vcb.SaveToFile("_" + fileName);

    }
}
