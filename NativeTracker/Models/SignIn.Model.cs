using System.Threading.Tasks;
using nativeTrackerClientLibrary;
using nativeTrackerClientLibrary.Services;

namespace NativeTracker.Models;

public class SignInModel
{
    private readonly ClientService _clientService = new();

    public static bool TryGetCredentials(out string token, out string login)
    {
        token = string.Empty;
        login = string.Empty;
        if (string.IsNullOrEmpty(Properties.User.Default.Login))
            return false;

        token = Properties.User.Default.Token;
        login = Properties.User.Default.Login;

        return true;
    }

    private static void ClearCredentials()
    {
        Properties.User.Default.Token = string.Empty;
        Properties.User.Default.Login = string.Empty;
        Properties.User.Default.Save();
    }

    private static void SaveCredentials(string token, string login)
    {
        Properties.User.Default.Token = token;
        Properties.User.Default.Login = login;
        Properties.User.Default.Save();
    }

    public async Task<bool> SignInAsync(string login, string password, bool rememberMe)
    {
        bool authorized = await _clientService.LoginAccountAsync(login, password);

        if (!authorized) 
            return false;
        
        if (rememberMe)
        {
            SaveCredentials(CredentialsManager.Token, login);
        }
        else
        {
            ClearCredentials();
        }

        return true;
    }

    public async Task<bool> ValidateAndSetToken(string token)
    {
        if (await _clientService.ValidateTokenAsync(token) == false)
            return false;
        
        CredentialsManager.Token = token;
        return true;
    }
}