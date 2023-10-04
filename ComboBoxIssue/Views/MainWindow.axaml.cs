using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ComboBoxIssue.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace ComboBoxIssue.Views;

public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.Users, v => v.UserComboBox.ItemsSource).DisposeWith(disposables);
        });
        InitializeComponent();
    }
}
