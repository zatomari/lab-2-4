using System.Text.RegularExpressions;


public class Program{
    public static void Main(string[] args){

        string fileName = "Dictionary.csv";
        Vocabulary vcb = Vocabulary.ReadFromFile(fileName);
        Regex rus = new Regex(@"([а-яА-Я]+)");

        string input;
        string inputRoot;

        Word[] words;

        Console.WriteLine("Словарь однокоренных слов");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Введите слово или q для завершения работы");

        try{
            input = Console.ReadLine().ToLower();
            if (input == "q"){
                return;
            }
            if (!rus.IsMatch (input)){
                Console.WriteLine ($"'{input}' не слово");
                return;
            }
            if (vcb.Has(input)){
                Console.WriteLine($"Слово '{input}' есть в словаре");
                inputRoot = vcb.GetRoot(input);
                Console.WriteLine($"Слова с корнем: '{inputRoot}'");
                words = vcb.GetWords(inputRoot);
                Array.Sort(words);
                foreach (Word word in words){
                    Console.WriteLine(word.Output());
                }
            } else{
                Console.WriteLine($"Слова '{input}' нет в словаре. Хотите его занести в словарь? y/n/q");
                string yesNo = Console.ReadLine().ToLower();
                if (yesNo == "y"){
                    Console.WriteLine("Недописано пока");
                }
            }
        }
        catch(IOException){
            Console.WriteLine("Ошибка ввода");
        }

    }
}
