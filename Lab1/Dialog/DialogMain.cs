namespace Lab1.Dialog;

using Lab1.Input;
using Lab1.Vocabulary;

// Класс основного диалога
public class DialogMain : Dialog {
    public DialogMain(Vocabulary vcb) : base(
        vcb,
        new Input(
            "> ",
            // Проверка на кириллицу или q
            (text) => Input.IsCyrillic(text) || text == "q",
            "Введите русское слово или q"
        ),
        // Диалог подтверждения ввода в словарь
        new DialogYesNo(vcb)
    ) {
    }

    protected override bool Action(String word) {
        word = input.Single();

        if (word == "q") {
            // выход из программы
            return false;
        } else if (word == "") {
            // если пустая строка, то переходим опять в режим ввода слова
            return true;
        }


        if (vcb.Has(word)) {
            Console.WriteLine("Известные однокоренные слова:");
            vcb.OutputKnownWords(word);
            return true;
        } else {
            nextDialog?.Run(word);
            return true;
        }
    }
}
