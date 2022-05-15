using System;
using nativeTrackerClientService;
using ReactiveUI.Fody.Helpers;

namespace NativeTracker.ViewModels.Guest;

public class LoginWindowViewModel : ViewModel
{
    [Reactive] public object View { get; set; }

    public Action OnSignedIn { get; set; }
    
    private SignInViewModel _signInVm;
    private SignUpViewModel _signUpVm;

    public LoginWindowViewModel()
    {
        CreateSignIn();
        CreateSignUp();
        
        // Set SignIn View by default
        View = _signInVm;
    }

    private void CreateSignIn()
    {
        _signInVm = new SignInViewModel();

        // Open SignUp View
        _signInVm.OnSignUpRequired += () => View = _signUpVm;

        // Open MainWindow
        _signInVm.LoginEnd += () =>
        {
            OnSignedIn?.Invoke();
        };
    }

    private void CreateSignUp()
    {
        _signUpVm = new SignUpViewModel();
        
        // Open SignIn View if created
        _signUpVm.LoginEnd += () =>
        {
            if (_signUpVm.CreateStatus != CreateStatus.Created)
                return;
            
            View = _signInVm;
            
            // Reset view
            CreateSignUp();
        };
        
        // Open SignIn View
        _signUpVm.CancelRequired += () =>
        {
            View = _signInVm;
            
            // Reset view
            CreateSignUp();
        };
    }
}