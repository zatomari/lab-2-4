using Lab2.Dialog;
using Lab2.Vocabulary;

public class Program {
    public static async Task Main(string[] args) {
        const string fileName = "Dictionary.csv";

        Vocabulary vcb = new Vocabulary();

        try {
            StreamReader reader = new StreamReader(fileName);

            await VocabularyManager.Read(vcb, reader);
        } catch (Exception e) {
            Console.WriteLine("\nUnable to read data from file " + fileName + "\nExiting…\n");
            // Console.WriteLine(e);
            return;
        }

        new DialogMain(vcb).Run("");

        try {
            StreamWriter writer = new StreamWriter(fileName);

            await VocabularyManager.Write(vcb, writer);
        } catch (Exception e) {
            Console.WriteLine("\nUnable to write data to file " + fileName + "\nExiting…\n");
            // Console.WriteLine(e);
            return;
        }
    }
}
