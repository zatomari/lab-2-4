namespace Lab4.WebApp;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Lab4.Vocabulary;
using Lab4.Word;

// Объект веб-приложения
public class WebApp {
    private Vocabulary vcb;
    private WebApplication app;

    // Создаём веб-приложение
    public WebApp(Vocabulary vcb) {
        this.vcb = vcb;
        // Создаем сервер
        app = WebApplication.Create();

    // Инициализируем конечные точки (end point)
        InitRoot();
        InitHas();
        InitGetWords();
        InitGetKnownWords();
        InitAddWord();
    }

    // Запускаем сервер
    public void Run() {
        app.Run();
    }

    // Инициализация запроса к корню сервера
    private void InitRoot() {
        app.MapGet("/", () =>
            "Usage:\n\n" +
            "/has/word — true — если слово есть в базе данных, false — если нет\n\n" +
            "/words/root — список всех слов в базе данных с корнем root\n\n" +
            "/known-words/word — список всех слов в базе данных, однокоренных переданному"
        );
    }

    // Метод Has через REST
    private void InitHas() {
        // /api/has?word=слово
        app.MapGet("/api/has", async (string word) => {
            bool result = await vcb.Has(word);

            return Results.Json(result);
        });
    }

    // Метод GetWords через REST
    private void InitGetWords() {
        // /api/words?root=корень
        app.MapGet("/api/words", async (string root) => {
            Word[] words = await vcb.GetWords(root);
            string[] result = new string[words.Length];

            for (int i = 0; i < words.Length; i++) {
                result[i] = words[i].ToString();
            }

            return Results.Json(result);
        });
    }

    // Метод GetKnownWords через REST
    private void InitGetKnownWords() {
        // /api/known-words?word=слово
        app.MapGet("/api/known-words", async (string word) => {
            Word[] words = await vcb.GetKnownWords(word);
            string[] result = new string[words.Length];

            for (int i = 0; i < words.Length; i++) {
                result[i] = words[i].Output();
            }

            return Results.Json(result);
        });
    }

    // Метод AddWord через REST
    private void InitAddWord() {
        // /api/add-word
        app.MapGet("/api/add-word", (string word) => {
            vcb.AddWord(Word.Deserialize(word));
        });
    }
}
