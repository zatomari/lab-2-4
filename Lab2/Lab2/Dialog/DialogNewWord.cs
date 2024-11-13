namespace Lab2.Dialog;

using Lab2.Input;
using Lab2.Vocabulary;
using Lab2.Word;

// Класс диалога для добавления слова в словарь
public class DialogNewWord : Dialog {
    public DialogNewWord(Vocabulary vcb) : base(
        vcb,
        new Input(
            "Введите части слова по порядку",
            (text) => Input.IsCyrillic(text) || text == "",
            "Введите русские буквы"
        )
    ) {
    }

    protected override Task<bool> Action(String word) {
        input.setPrompt("приставка: ");
        String[] prefix = input.Many();

        input.setPrompt("корень: ");
        String root = input.Single("Корень должен быть обязательно указан!");

        input.setPrompt("суффикс: ");
        String[] suffix = input.Many();

        input.setPrompt("окончание: ");
        String ending = input.Single();

        Word newWord = new Word(
            new WordPrefix(prefix),
            new WordRoot(root),
            new WordSuffix(suffix),
            new WordEnding(ending)
        );

        // Сравниваем введенное слово с введенным ранее,
        // если совпадает то добавляем в словарь
        if (word == newWord.ToString()) {
            vcb.AddWord(newWord);
            Console.WriteLine($"Слово “{newWord}“ добавлено");
            return Task.FromResult(false);
        }

        Console.WriteLine($"Слово “{word}“ не соответствует введёному по частям “{newWord}“");
        return Task.FromResult(true);
    }
}
