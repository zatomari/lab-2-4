namespace Lab4.ViewModels;

using System.Text;
using System.Text.RegularExpressions;
using ReactiveUI;
using Avalonia.Data;

using Lab4.WebClient;
using Lab4.Word;

public class MainWindowViewModel : ReactiveObject {
    private WebClient webClient = new WebClient();
    private static Regex IsCyrillic = new Regex(@"^[а-яА-Я]+$");

    public MainWindowViewModel() {
        // При изменении свойства "Word" ожидаем,
        // изменения свойства "KnownWords"
        this
            .WhenAnyValue(o => o.Word)
            .Subscribe(o => GetKnownWordsAsync());
    }

    // Свойство проверки введёенного текста на правильность.
    // Введенный текст считается правильным, если он:
    // 1) пустой или состоит из пробелов
    // 2) не пустой и состоит из русских букв
    private bool IsValid(string? value) {
        return string.IsNullOrWhiteSpace(value) ||
            (!string.IsNullOrWhiteSpace(value) && IsCyrillic.IsMatch(value));
    }

    private void CheckCyrillic(string? value) {
        if (!IsValid(value)) {
            throw new DataValidationException("Можно вводить только русские буквы");
        }
    }

    private string _word = "";
    public string Word {
        get => _word;
        set {
            this.RaiseAndSetIfChanged(ref _word, value);

            CheckCyrillic(value);
        }
    }

    private string[] _prefix = ["", ""];
    public string Prefix1 {
        get => _prefix[0];
        set {
            this.RaiseAndSetIfChanged(ref _prefix[0], value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    public string Prefix2 {
        get => _prefix[1];
        set {
            this.RaiseAndSetIfChanged(ref _prefix[1], value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string _root = "";
    public string Root {
        get => _root;
        set {
            this.RaiseAndSetIfChanged(ref _root, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string[] _suffix = ["", "", ""];
    public string Suffix1 {
        get => _suffix[0];
        set {
            this.RaiseAndSetIfChanged(ref _suffix[0], value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    public string Suffix2 {
        get => _suffix[1];
        set {
            this.RaiseAndSetIfChanged(ref _suffix[1], value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    public string Suffix3 {
        get => _suffix[2];
        set {
            this.RaiseAndSetIfChanged(ref _suffix[2], value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    private string _ending = "";
    public string Ending {
        get => _ending;
        set {
            this.RaiseAndSetIfChanged(ref _ending, value);

            // Уведомляем кнопку добавления слова, что она должна поменять своё состояние
            this.RaisePropertyChanged(nameof(AddWordButtonEnabled));

            CheckCyrillic(value);
        }
    }

    // Метод проверяет можно ли разблокировать кнопку добавления слова
    public bool AddWordButtonEnabled {
        get => !string.IsNullOrWhiteSpace(_root) &&
            IsValid(_prefix[0]) &&
            IsValid(_prefix[1]) &&
            IsValid(_root) &&
            IsValid(_suffix[0]) &&
            IsValid(_suffix[1]) &&
            IsValid(_suffix[2]) &&
            IsValid(_ending);
    }

    public async void AddWord() {
        Word word = new Word(
            new WordPrefix(_prefix),
            new WordRoot(_root),
            new WordSuffix(_suffix),
            new WordEnding(_ending)
        );

        await webClient.AddWord(word);

        GetKnownWordsAsync();
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

        if (await webClient.Has(Word)) {
            StringBuilder result = new StringBuilder();
            string?[] words = await webClient.GetKnownWords(Word);

            foreach (string? w in words) {
                result.Append(w);
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
