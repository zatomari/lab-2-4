using Lab2.Dialog;
using Lab2.Vocabulary;

public class Program {
    public static async Task Main() {
        VocabularyManager manager = new VocabularyManager();
        Vocabulary vcb = new Vocabulary();

        await manager.Read(vcb);

        new DialogMain(vcb).Run("");

        await manager.Write(vcb);
    }
}
