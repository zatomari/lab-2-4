namespace Lab4.ViewModels;

using System.Text;
using ReactiveUI;

using Lab4.Vocabulary;
using Lab4.Word;

public class MainWindowViewModel : ReactiveObject {
    protected static Vocabulary vocabulary = new Vocabulary("Dictionary.db");

    public MainWindowViewModel() {
        // We can listen to any property changes with "WhenAnyValue"
        // and do whatever we want in "Subscribe".
        this
            .WhenAnyValue(o => o.Word)
            .Subscribe(o => GetKnownWordsAsync());
    }

    private string? _Word; // This is our backing field for Word

    public string? Word {
        get {
            return _Word;
        }
        set {
            // We can use "RaiseAndSetIfChanged" to check
            // if the value changed and automatically notify the UI
            this.RaiseAndSetIfChanged(ref _Word, value);
        }
    }

    private async void GetKnownWordsAsync() {
        string knownWords = await GetKnownWords();

        if (_KnownWords != knownWords) {
            _KnownWords = knownWords;

            // Уведомляем UI, что значение изменилось
            this.RaisePropertyChanged(nameof(KnownWords));
        }
    }

    private async Task<string> GetKnownWords() {
        if (Word is null || Word.Trim() == "") {
            return "введите слово в поле ввода";
        }

        if (await vocabulary.Has(Word)) {
            StringBuilder result = new StringBuilder();
            Word[] words = await vocabulary.GetKnownWords(Word);

            foreach (Word w in words) {
                result.Append(w.Output());
                result.Append("\n");
            }

            return result.ToString();
        }

        return "однокоренных слов нет";
    }

    private string _KnownWords = "";

    // KnownWords will change based on a Word.
    public string KnownWords {
        get {
            return _KnownWords;
        }
    }
}
