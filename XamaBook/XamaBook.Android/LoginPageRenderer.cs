using Android.App;
using Android.Content;
using Newtonsoft.Json.Linq;
using System;
using XamaBook;
using XamaBook.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]

namespace XamaBook.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        public LoginPageRenderer(Context context) : base(context)
        {
            var authenticator = new OAuth2Authenticator
            (
                clientId: "206990856892356", 
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
            );

            authenticator.Completed += Authenticator_Completed;

            var activity = (Activity)context;
            activity.StartActivity(authenticator.GetUI(activity));
        }

        private async void Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, e.Account);
                var response = await request.GetResponseAsync();
                var userInfo = JObject.Parse(response.GetResponseText());
                var name = userInfo["name"].ToString().Replace("\"", "");

                await App.NavigateToProfile($"Olá {name}, seja bem vindo :)");
            }
            else
            {
                await App.NavigateToProfile("Usuário Cancelou o login");
            }
        }
    }
}