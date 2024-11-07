using Lab2.Dialog;
using Lab2.Vocabulary;

public class Program {
    public static async Task Main() {
        Vocabulary vcb = new Vocabulary();

        await VocabularyManager.Read(vcb);

        new DialogMain(vcb).Run("");

        await VocabularyManager.Write(vcb);
    }
}
