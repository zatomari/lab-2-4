namespace Lab2.Dialog;

using Lab2.Input;
using Lab2.Vocabulary;
using Lab2.Word;

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
        Console.WriteLine("Словарь однокоренных слов");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Введите слово или q для завершения работы");
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
            IReadOnlyCollection<Word> words = vcb.GetKnownWords(word);

            Console.WriteLine("Известные однокоренные слова:");

            foreach (Word w in words) {
                Console.WriteLine(w.Output());
            }

            return true;
        } else {
            nextDialog?.Run(word);
            return true;
        }
    }
}
