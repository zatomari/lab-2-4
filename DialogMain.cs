
// Класс диалога
public class DialogMain : Dialog {
    public DialogMain(Vocabulary vcb) : base(
        vcb,
        new Input(
            "> ",
            (text) => Input.IsCyrillic(text) || text == "q",
            "Введите русское слово или q"
        ),
        new DialogYesNo(vcb)
    ) {
    }

    protected override bool Action(String word) {
        word = input.Single();

        if (word == "q") {
            return true;
        } else if (word == "") {
            return false;
        }

        if (vcb.Has(word)) {
            Console.WriteLine("Известные однокоренные слова:");
            vcb.OutputKnownWords(word);
            return false;
        } else {
            nextDialog?.Run(word);
            return false;
        }
    }
}
