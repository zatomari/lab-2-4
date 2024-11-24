namespace Lab4.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    public MainWindowViewModel() {
    }

    public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
}
