namespace Lab4.ViewModels;

using System.Text;
using System.Text.RegularExpressions;
using ReactiveUI;
using Avalonia.Data;

using Lab4.Vocabulary;
using Lab4.Word;

public class MainWindowViewModel : ReactiveObject {
    private static Regex IsCyrillic = new Regex(@"^[а-яА-Я]+$");

    protected static Vocabulary vocabulary = new Vocabulary("Dictionary.db");

    public MainWindowViewModel() {
        // При изменении свойства "Word" ожидаем,
        // изменения свойства "KnownWords"
        this
            .WhenAnyValue(o => o.Word)
            .Subscribe(o => GetKnownWordsAsync());
    }

    private bool IsValid(string? value) {
        return string.IsNullOrWhiteSpace(value) ||
            (!string.IsNullOrWhiteSpace(value) && IsCyrillic.IsMatch(value));
    }

    private void CheckCyrillic(string? value) {
        if (!IsValid(value)) {
            throw new DataValidationException("Можно вводить только русские буквы");
        }
    }

    private string? _word;
    public string? Word {
        get => _word;
        set {
            this.RaiseAndSetIfChanged(ref _word, value);

            CheckCyrillic(value);
        }
    }

    private string? _prefix1;
    public string? Prefix1 {
        get => _prefix1;
        set {
            this.RaiseAndSetIfChanged(ref _prefix1, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string? _prefix2;
    public string? Prefix2 {
        get => _prefix2;
        set {
            this.RaiseAndSetIfChanged(ref _prefix2, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string? _root;
    public string? Root {
        get => _root;
        set {
            this.RaiseAndSetIfChanged(ref _root, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string? _suffix1;
    public string? Suffix1 {
        get => _suffix1;
        set {
            this.RaiseAndSetIfChanged(ref _suffix1, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string? _suffix2;
    public string? Suffix2 {
        get => _suffix2;
        set {
            this.RaiseAndSetIfChanged(ref _suffix2, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string? _suffix3;
    public string? Suffix3 {
        get => _suffix3;
        set {
            this.RaiseAndSetIfChanged(ref _suffix3, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string? _ending;
    public string? Ending {
        get => _ending;
        set {
            this.RaiseAndSetIfChanged(ref _ending, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    public bool AddWordButtonEnabled {
        get => !string.IsNullOrWhiteSpace(_root) &&
            IsValid(_prefix1) &&
            IsValid(_prefix2) &&
            IsValid(_root) &&
            IsValid(_suffix1) &&
            IsValid(_suffix2) &&
            IsValid(_suffix3) &&
            IsValid(_ending);
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
}
