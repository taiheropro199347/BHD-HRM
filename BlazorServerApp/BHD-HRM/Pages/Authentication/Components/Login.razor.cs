using BHD_HRM.Data;
using BHD_HRM.Data.Users;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BHD_HRM.Pages.Authentication.Components;
public partial class Login
{
    class Model
    { 
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string _password { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string _user { get; set; }
    }

    private bool _show;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    [Parameter]
    public bool HideLogo { get; set; }

    [Parameter]
    public double Width { get; set; } = 410;

    [Parameter]
    public StringNumber? Elevation { get; set; }

    [Parameter]
    public string CreateAccountRoute { get; set; } = $"pages/authentication/register-v1";

    [Parameter]
    public string ForgotPasswordRoute { get; set; } = $"pages/authentication/forgot-password-v1";

    //[Parameter]
    //public EventCallback<MouseEventArgs> OnLogin { get; set; }
    private User user;
    private Model _model = new();
    public string LoginMesssage { get; set; }
    ClaimsPrincipal claimsPrincipal;

    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    protected async override Task OnInitializedAsync()
    {
        user = new User();

        claimsPrincipal = (await authenticationStateTask).User;

        if (claimsPrincipal.Identity.IsAuthenticated)
        {
            NavigationManager.NavigateTo("/dashboard/ecommerce");
        }

    }
    private async void HandleOnValidSubmit()
    {
        user = new User();

        claimsPrincipal = (await authenticationStateTask).User;

        user.userAd = _model._user;
        user.pass=_model._password;
        var returnedUser = await userService.LoginAsync(user);

        if (returnedUser.userAd != null)
        {
            await((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(returnedUser);
            NavigationManager.NavigateTo("/dashboard/ecommerce");
        }
        else
        {
            LoginMesssage = "Invalid username or password";
        }
    }
}

