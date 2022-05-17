using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace NativeTracker.ViewModels.Assets;

public class IssuesViewModel : ViewModel
{
    public ICommand CreateIssueCommand { get; }

    public IssuesViewModel()
    {
        CreateIssueCommand = ReactiveCommand.CreateFromTask(async () =>
        { 
            var vm = await Interactions.CreateIssueInteraction.Handle(Unit.Default);
        });
    }
}