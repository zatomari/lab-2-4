using Avalonia;
using Avalonia.ReactiveUI;

using Lab4.Vocabulary;
using Lab4.WebApp;

public class Program {
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) {
        // Запускаем словарь и веб-приложение в отдельный поток,
        // иначе почему-то Avalonia не запускается
        Task.Run(() => {
            Vocabulary vocabulary = new Vocabulary("Dictionary.db");
            WebApp webapp = new WebApp(vocabulary);

            webapp.Run();
        });

        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp() {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
    }
}
