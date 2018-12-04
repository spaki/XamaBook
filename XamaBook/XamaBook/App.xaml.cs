using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamaBook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static Action HideLoginView
        {
            get
            {
                return new Action(() => Current.MainPage.Navigation.PopModalAsync());
            }
        }

        public async static Task NavigateToProfile(string message)
        {
            await Current.MainPage.Navigation.PushAsync(new ProfilePage(message));
        }
    }
}
