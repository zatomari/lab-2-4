using Lab1.Dialog;
using Lab1.Vocabulary;

public class Program {
    public static async Task Main(string[] args) {
        const string fileName = "Dictionary.csv";

        Vocabulary vcb = new Vocabulary();

        await VocabularyManager.Read(vcb, new StreamReader(fileName));

        new DialogMain(vcb).Run("");

        await VocabularyManager.Write(vcb, new StreamWriter(fileName));
    }
}
