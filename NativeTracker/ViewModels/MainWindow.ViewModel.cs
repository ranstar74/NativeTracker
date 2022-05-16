using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NativeTracker.ViewModels.Assets;
using NativeTracker.ViewModels.Guest;
using ReactiveUI;

namespace NativeTracker.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        // public ICommand LoginCommand { get; }
        
        public MainWindowViewModel()
        {
            // LoginCommand = ReactiveCommand.CreateFromTask(async () =>
            // {
            //     await ShowLoginTask();
            // });
        }
        //
        // public async void EnsureAuthorized()
        // {
        //     await ShowLoginTask();
        // }
        //
        // private async Task ShowLoginTask()
        // {
        //     var loginView = new SignInViewModel();
        //
        //     var result = await ShowLoginDialogInteraction.Handle(loginView);
        // }
    }
}