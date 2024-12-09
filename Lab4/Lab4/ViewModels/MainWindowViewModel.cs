namespace Lab4.ViewModels;

using System.Text;
using System.Text.RegularExpressions;
using ReactiveUI;

using Lab4.Vocabulary;
using Lab4.Word;

public class MainWindowViewModel : ReactiveObject {
    private static Regex IsCyrillic = new Regex(@"[а-яА-Я]+");

    protected static Vocabulary vocabulary = new Vocabulary("Dictionary.db");

    public MainWindowViewModel() {
        // При изменении свойства "Word" ожидаем,
        // изменения свойства "Error"
        this
            .WhenAnyValue(o => o.Word)
            .Subscribe(o => CheckRussian());

        // При изменении свойства "Word" ожидаем,
        // изменения свойства "KnownWords"
        this
            .WhenAnyValue(o => o.Word)
            .Subscribe(o => GetKnownWordsAsync());
    }

    private string? _word;

    public string? Word {
        get {
            return _word;
        }
        set {
            // Поверяем, что свойство "Word" изменилось,
            // Уведомляем UI
            this.RaiseAndSetIfChanged(ref _word, value);
        }
    }

    private void CheckRussian() {
        if (_word != null && _word.Trim() != "" && !IsCyrillic.IsMatch(_word)) {
            _error = "Введите русское слово";
        } else {
            _error = "";
        }

        this.RaisePropertyChanged(nameof(Error));
    }

    private async void GetKnownWordsAsync() {
        string getKnownWords = await GetKnownWords();

        if (_knownWords != getKnownWords) {
            _knownWords = getKnownWords;

            // Уведомляем UI, что значение "KnownWords" изменилось
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

    private string _knownWords = "";

    // KnownWords will change based on a Word.
    public string KnownWords {
        get {
            return _knownWords;
        }
    }

    private string _error = "";

    public string Error {
        get {
            return _error;
        }
    }
}
