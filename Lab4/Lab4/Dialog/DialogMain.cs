namespace Lab4.Dialog;

using Lab4.Input;
using Lab4.Vocabulary;
using Lab4.Word;

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

    protected override async Task<bool> Action(String word) {
        word = input.Single();

        if (word == "q") {
            // выход из программы
            return false;
        } else if (word == "") {
            // если пустая строка, то переходим опять в режим ввода слова
            return true;
        }

        if (await vcb.Has(word)) {
            Word[] words = await vcb.GetKnownWords(word);

            Console.WriteLine("Известные однокоренные слова:");

            foreach (Word w in words) {
                Console.WriteLine(w.Output());
            }

            return true;
        } else {
            if (nextDialog != null) {
                await nextDialog.Run(word);
            }
            return true;
        }
    }
}
