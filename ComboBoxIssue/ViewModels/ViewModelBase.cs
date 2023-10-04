using ReactiveUI;

namespace ComboBoxIssue.ViewModels;

public class ViewModelBase : ReactiveObject, IActivatableViewModel
{
    public ViewModelActivator Activator { get; }

    public ViewModelBase()
    {
        Activator = new ViewModelActivator();
    }
}
