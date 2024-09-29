// Класс корня
public class WordRoot : WordPart{

    public WordRoot() : base(){}

    public WordRoot(string root) : base(root){}

    public override string Output(){
        return part[0];
    }
}