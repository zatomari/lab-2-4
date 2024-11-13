namespace Lab2.Dialog;

using Lab2.Input;
using Lab2.Vocabulary;

// Абстрактный класс диалога
public abstract class Dialog {
    // Словарь
    protected Vocabulary vcb;
    // Объект ввода строки от пользователя
    protected Input input;
    // Следующий диалог для показа
    protected Dialog? nextDialog;

    public Dialog(Vocabulary vcb, Input input, Dialog? nextDialog = null) {
        this.vcb = vcb;
        this.input = input;
        this.nextDialog = nextDialog;
    }

    // Метод запуска диалога
    // Параметр: введенное слово
    public async Task Run(String word) {
        while (true) {
            if (!await Action(word)) {
                break;
            }
        }
    }

    protected abstract Task<bool> Action(String text);
}
