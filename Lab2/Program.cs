using Lab2.Dialog;
using Lab2.Vocabulary;

public class Program {
    public static async Task Main() {
        Vocabulary vocabulary = new Vocabulary("Dictionary.db");

        await new DialogMain(vocabulary).Run("");
    }
}
