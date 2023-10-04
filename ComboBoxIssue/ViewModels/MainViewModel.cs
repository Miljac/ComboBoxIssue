using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System;
using System.Reactive.Disposables;

namespace ComboBoxIssue.ViewModels;

public class MainViewModel : ViewModelBase
{
    private SourceList<User> _sourceList;

    public ReadOnlyObservableCollection<User> Users;
    public string Greeting => "Welcome to Avalonia!";
    

    public MainViewModel()
    {
        _sourceList = new SourceList<User>();
        this.WhenActivated(disposables => { 
            _sourceList.Connect().ObserveOn(RxApp.MainThreadScheduler).Bind(out Users).Subscribe().DisposeWith(disposables);
        });
        _sourceList.Add(new User() { Name = "Jhon", Age=54 });
        _sourceList.Add(new User() { Name = "Ivan", Age=45 });
        _sourceList.Add(new User() { Name = "Mark", Age=33 });
    }
}
