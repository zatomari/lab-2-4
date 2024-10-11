using System.Text.RegularExpressions;

// Класс диалога
public abstract class Dialog {
    protected Vocabulary vcb;
    protected Input input;
    protected Dialog? nextDialog;

    public Dialog(Vocabulary vcb, Input input, Dialog? nextDialog = null) {
        this.vcb = vcb;
        this.input = input;
        this.nextDialog = nextDialog;
    }

    public void Run(String word) {
        while (true) {
            if (Action(word)) {
                break;
            }
        }
    }

    protected abstract bool Action(String text);
}
