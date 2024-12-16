namespace Lab4.WebClient;

using System.Net.Http;
using Newtonsoft.Json.Linq;

using Lab4.Word;

// Объект веб-приложения
public class WebClient {
    private string root = "http://localhost:5000";
    private HttpClient client = new HttpClient();

    public WebClient() {
    }

    public async Task<bool> Has(string word) {
        var response = await client.GetAsync(root + "/api/has?word=" + word);

        if (!response.IsSuccessStatusCode) {
            Console.WriteLine($"Error: {response.StatusCode}");

            return false;
        }

        string result = await response.Content.ReadAsStringAsync();

        return result == "true";
    }

    public async Task<string?[]> GetKnownWords(string word) {
        var response = await client.GetAsync(root + "/api/known-words?word=" + word);

        if (!response.IsSuccessStatusCode) {
            Console.WriteLine($"Error: {response.StatusCode}");

            return [$"Error: {response.StatusCode}"];
        }

        string json = await response.Content.ReadAsStringAsync();

        return JArray.Parse(json).Values<string>().ToArray();
    }

    public async Task AddWord(Word word) {
        var response = await client.PostAsync(
            root + "/api/add-word",
            new StringContent(word.Serialize())
        );

        if (!response.IsSuccessStatusCode) {
            Console.WriteLine($"Error: {response.StatusCode}");

            return;
        }
    }
}
