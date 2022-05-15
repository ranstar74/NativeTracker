using System;
using System.Security.Cryptography;
using System.Windows.Input;
using nativeTrackerClientService;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ClientService = nativeTrackerClientLibrary.Services.ClientService;

namespace NativeTracker.ViewModels.Guest;

public class SignUpViewModel : ValidatableViewModel
{
    [Reactive] public string Login { get; set; } = string.Empty;
    [Reactive] public string Password { get; set; } = string.Empty;
    [Reactive] public string ConfirmPassword { get; set; } = string.Empty;

    public Action LoginBegin { get; set; }
    public Action LoginEnd { get; set; }
    public Action CancelRequired { get; set; }

    public ICommand CreateAccountCommand { get; }

    [Reactive] public bool IsCreating { get; private set; }

    [Reactive] public CreateStatus CreateStatus { get; private set; }

    private readonly ClientService _clientService = new();

    public SignUpViewModel()
    {
        // Passwords don't match
        var passwordsObservable =
            this.WhenAnyValue(
                x => x.Password,
                x => x.ConfirmPassword,
                (password, confirmation) => password == confirmation);

        this.ValidationRule(
            vm => vm.ConfirmPassword,
            passwordsObservable,
            "Passwords must match.");

        // Login taken
        var loginTakenObservable = this.WhenAnyValue(
            x => x.CreateStatus,
            status => status != CreateStatus.LoginTaken);

        this.ValidationRule(
            vm => vm.Login,
            loginTakenObservable,
            "Login is already taken.");

        // Login format is not valid
        var loginFormatObservable = this.WhenAnyValue(
            x => x.CreateStatus,
            status => status != CreateStatus.LoginFormatIsNotValid);

        this.ValidationRule(
            vm => vm.Login,
            loginFormatObservable,
            "Login format is not valid.");

        // Login must be different from password
        var loginEqualityObservable = this.WhenAnyValue(
            x => x.CreateStatus,
            status => status != CreateStatus.LoginMustBeDifferentFromPassword);

        this.ValidationRule(
            vm => vm.Login,
            loginEqualityObservable,
            "Login must be different from password.");

        // Password format is not valid
        var passwordFormatObservable = this.WhenAnyValue(
            x => x.CreateStatus,
            status => status != CreateStatus.PasswordFormatIsNotValid);

        this.ValidationRule(
            vm => vm.Password,
            passwordFormatObservable,
            "Password should contain one digit, lower and capital letter, " +
            "special character and no white space and be at least 8 characters long.");

        var canCreateObservable = this.WhenAnyValue(
            x => x.HasErrors,
            x => x.IsCreating,
            (hasErrors, isCreating) => !hasErrors && !isCreating);

        CreateAccountCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            IsCreating = true;
            LoginBegin?.Invoke();
            
            CreateStatus = await _clientService.CreateAccount(new CreateAccountRequest()
            {
                Login = Login,
                Password = Password
            });

            LoginEnd?.Invoke();
            IsCreating = false;
        }, canCreateObservable);

        // Reset status when any value changes
        this.WhenAnyValue(
            x => x.Login,
            x => x.Password,
            x => x.ConfirmPassword)
            .Subscribe(tuple =>
        {
            CreateStatus = CreateStatus.Created;
        });
    }

    public void Cancel()
    {
        CancelRequired?.Invoke();
    }
}