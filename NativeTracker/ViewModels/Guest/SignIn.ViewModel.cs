using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NativeTracker.Models;
using nativeTrackerClientLibrary.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;

namespace NativeTracker.ViewModels.Guest;

public class SignInViewModel : ValidatableViewModel
{
    [Reactive] public string Login { get; set; } = string.Empty;
    [Reactive] public string Password { get; set; } = string.Empty;

    public Action LoginBegin { get; set; }
    public Action LoginEnd { get; set; }
    public Action OnSignUpRequired { get; set; }

    private ICommand SignInCommand { get; }

    [Reactive] public bool IsAuthorized { get; private set; }
    [Reactive] public bool LoginOrPasswordIsInvalid { get; private set; }
    [Reactive] public bool IsSigningIn { get; private set; }

    [Reactive] public bool RememberMe { get; set; }

    private readonly SignInModel _model = new();

    public SignInViewModel()
    {
        // Login or password is invalid
        var cantSignInObservable = this.WhenAnyValue(
            x => x.LoginOrPasswordIsInvalid,
            isLoginOrPasswordInvalid => !isLoginOrPasswordInvalid);

        this.ValidationRule(
            vm => vm.Login,
            cantSignInObservable,
            "Login or password is invalid.");

        this.ValidationRule(
            vm => vm.Password,
            cantSignInObservable,
            string.Empty); // Just highlight password without error text

        // Reset errors when any value changes
        this.WhenAnyValue(
                x => x.Login,
                x => x.Password)
            .Subscribe(_ => { LoginOrPasswordIsInvalid = false; });

        var canSignIn = this.WhenAnyValue(
            x => x.IsSigningIn,
            isSigningIn => !isSigningIn);

        SignInCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            IsSigningIn = true;
            LoginBegin?.Invoke();

            IsAuthorized = await _model.SignInAsync(Login, Password, RememberMe);
            LoginOrPasswordIsInvalid = !IsAuthorized;

            LoginEnd?.Invoke();
            IsSigningIn = false;
        }, canSignIn);

        TryAutoSignIn();
    }

    private async void TryAutoSignIn()
    {
        if (!SignInModel.TryGetCredentials(out string token, out string login))
            return;

        Login = login;
        Password = "placeholder"; // We don't have actual password so just but something for look
        RememberMe = true;

        LoginBegin?.Invoke();
        IsSigningIn = true;

        IsAuthorized = await _model.ValidateAndSetToken(token);
        LoginOrPasswordIsInvalid = !IsAuthorized;

        LoginEnd?.Invoke();
        IsSigningIn = false;
    }

    public void SignUp()
    {
        OnSignUpRequired?.Invoke();
    }
}