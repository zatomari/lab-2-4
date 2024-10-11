using System.Text.RegularExpressions;

// Класс диалога
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

    public delegate bool IsValidInput(String text);

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

            if (required != null && result == "") {
                // и идём опять по циклу
                Console.WriteLine(required);
            } else if (!isValidInput(result)) {
                // и идём опять по циклу
                Console.WriteLine(invalidInputString);
            } else {
                return result;
            }
        }
    }

    public String[] Many(String? required = null) {
        List<String> result = new List<String>();
        String item;

        while (true) {
            item = Single(required);

            if (item == "") {
                return result.ToArray();
            }

            result.Add(item);
        }
    }
}
