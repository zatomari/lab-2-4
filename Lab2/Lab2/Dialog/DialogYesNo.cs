namespace Lab2.Dialog;

using Lab2.Input;
using Lab2.Vocabulary;

// Класс диалога
public class DialogYesNo : Dialog {
    public DialogYesNo(Vocabulary vcb) : base(
        vcb,
        new Input(
            "Неизвестное слово. Хотите добавить его в словарь (y/n)? ",
            (text) => text == "y" || text == "n",
            "Введите y или n"
        ),
        new DialogNewWord(vcb)
    ) {
    }

    protected override bool Action(String word) {
        String yesOrNo = input.Single();

        if (yesOrNo == "y") {
            nextDialog?.Run(word);
        }

        return false;
    }
}
