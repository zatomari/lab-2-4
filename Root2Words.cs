using System.Text;
// Класс словарь вида корень-список слов
public class Root2Words{

    private Dictionary<string, List<Word>> root2Words;

    public Root2Words (){
        root2Words = new Dictionary<string, List<Word>> ();
    }

    public Word[] GetWords(string root){
        if (!root2Words.ContainsKey(root)){
            return new Word[0];
        }
        return root2Words[root].ToArray();
    }

    public void AddWord(Word word){
        string root = word.GetRoot().ToString();
        List<Word> words;
        if (root2Words.ContainsKey(root)){
            words = root2Words[root];
        }else{
            words = new List<Word>();
            root2Words[root] = words;
        }
        words.Add(word);
    }

    // ?????
        public string Serialize()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (List<Word> words in root2Words.Values)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append("\n");
                }
                stringBuilder.Append(words[i].Serialize());
            }
        }

        return stringBuilder.ToString();
    }

}
