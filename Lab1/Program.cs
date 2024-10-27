using Lab1.Dialog;
using Lab1.Vocabulary;

public class Program {
    public static async Task Main(string[] args) {
        const string fileName = "Dictionary.csv";

        Vocabulary vcb = new Vocabulary();

        await VocabularyManager.ReadVocabularyFromFile(vcb, fileName);

        new DialogMain(vcb).Run("");

        await VocabularyManager.SaveVocabularyToFile(vcb, fileName);
    }
}
