using EmployeeCrudBlazor.Data.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmployeeCrudBlazor.Components.Pages.Account
{
    public partial class Login
    {
        [Inject]
        public IHttpContextAccessor Context { get; set; }
        [SupplyParameterFromForm]
        public LoginViewModel Model { get; set; } = new LoginViewModel();

        private string? errorMessage;
        public HttpContext? _httpContext { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(!firstRender)
            {
                return;
            }
            _httpContext = Context.HttpContext;
        }

        private async Task Authenticate()
        {

            if (ApplicationDbContext == null)
            {
                errorMessage = "Database context not available.";
                return;
            }


            if (Model == null || string.IsNullOrEmpty(Model.UserName) || string.IsNullOrEmpty(Model.Password))
            {
                errorMessage = "Username or password cannot be empty.";
                return;
            }


            var userAccount = await ApplicationDbContext.UserAccounts.FirstOrDefaultAsync(x => x.Username == Model.UserName);


            if (userAccount == null || userAccount.Password != Model.Password)
            {
                errorMessage = "Invalid User Name or Password";
                return;
            }


            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Model.UserName),
            new Claim(ClaimTypes.Role, userAccount.Role)
        };


            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);


            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            NavigationManager.NavigateTo("/");
        }
    }

}