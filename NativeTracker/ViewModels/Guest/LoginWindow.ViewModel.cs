using nativeTrackerClientService;
using ReactiveUI.Fody.Helpers;

namespace NativeTracker.ViewModels.Guest;

public class LoginWindowViewModel : ViewModel
{
    [Reactive] public object View { get; set; }

    private readonly SignInViewModel _signInVm;
    private SignUpViewModel _signUpVm;

    public LoginWindowViewModel()
    {
        _signInVm = new SignInViewModel();
        _signUpVm = new SignUpViewModel();

        // Set SignIn View by default
        View = _signInVm;

        // Open SignUp View
        _signInVm.OnSignUpRequired += () => View = _signUpVm;
        
        // Open SignIn View if created
        _signUpVm.LoginEnd += () =>
        {
            if (_signUpVm.CreateStatus != CreateStatus.Created)
                return;
            
            View = _signInVm;
            
            // Reset view
            _signUpVm = new SignUpViewModel();
        };
        
        // Open SignIn View
        _signUpVm.CancelRequired += () =>
        {
            View = _signInVm;
            
            // Reset view
            _signUpVm = new SignUpViewModel();
        };
    }
}