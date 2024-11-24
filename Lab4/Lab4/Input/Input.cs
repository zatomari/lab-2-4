namespace Lab4.Input;

using System.Text.RegularExpressions;

// Контейнер для поля ввода. Содержит в себе пояснительную строку prompt, выражение isValidInput для проверки на правильность введенного, сообщение invalidInputString, на случай если введено неправильно
// Обрабатывает данные, вводимые пользователем с помощью isValidInput
public class Input {
    private static Regex isCyrillic = new Regex(@"[а-яА-Я]+");

    private String prompt;

    private IsValidInput isValidInput;

    private String? invalidInputString;

    public Input(String prompt, IsValidInput isValidInput, String invalidInputString) {
        this.prompt = prompt;
        this.isValidInput = isValidInput;
        this.invalidInputString = invalidInputString;
    }

    public void setPrompt(String prompt) {
        this.prompt = prompt;
    }

    public static bool IsCyrillic(String text) {
        return isCyrillic.IsMatch(text);
    }

    // Делегат для лямбда выражения, вид которого будет указан в момент создания
    public delegate bool IsValidInput(String text);

    // Метод для ввода одного значения (слово, корень, окончание). Если required указан, то ввод элемента обязателен, в противном случае может быть пустой строкой
    public String Single(String? required = null) {
        String? result;

        while (true) {
            Console.Write(prompt);

            try {
                result = Console.ReadLine();

                result = result == null ? "" : result.Trim().ToLower();
            } catch(Exception) {
                result = "";
            }

            // Если required указан, а пользователь ввел пустое, то будем идти по циклу, пока пользоватеь не введет нужное
            if (required != null && result == "") {
                Console.WriteLine(required);
            } else if (!isValidInput(result)) {
                // Если опять введено неправильно, показываем это и заставляем вводить снова
                Console.WriteLine(invalidInputString);
            } else {
                return result;
            }
        }
    }

    // Метод для ввода множества значений (приставка, суффикс). В результате возвращается массив, состоящий из введённых значений
    public String[] Many() {
        List<String> result = new List<String>();
        String item;

        while (true) {
            item = Single();

            if (item == "") {
                return result.ToArray();
            }

            result.Add(item);
        }
    }
}
