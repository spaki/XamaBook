
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamaBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage (string message)
		{
			InitializeComponent ();

            this.lblMessage.Text = message;
        }
	}
}