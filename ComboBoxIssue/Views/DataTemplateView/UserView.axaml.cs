using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive.Disposables;

namespace ComboBoxIssue;

public partial class UserView : ReactiveUserControl<User>
{
    public UserView()
    {
        this.WhenActivated(disposables => {
            this.Bind(ViewModel, vm => vm.Name, v => v.NameTextBlock.Text).DisposeWith(disposables);
        });
        InitializeComponent();
    }
}