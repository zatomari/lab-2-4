namespace Lab4.ViewModels;

using ReactiveUI;

using Lab4.Vocabulary;

public class ViewModelBase : ReactiveObject {
    protected static Vocabulary vocabulary = new Vocabulary("Dictionary.db");
}
