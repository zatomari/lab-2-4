using Lab4.Dialog;
using Lab4.Vocabulary;

public class Program {
    public static async Task Main() {
        Vocabulary vocabulary = new Vocabulary("Dictionary.db");

        await new DialogMain(vocabulary).Run("");
    }
}
