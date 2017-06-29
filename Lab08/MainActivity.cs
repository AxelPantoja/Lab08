using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView tvName;
        TextView tvStatus;
        TextView tvToken;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //var ViewGroup = (Android.Views.ViewGroup)
            //    Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //
            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;
            //
            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            //
            //MainLayout.AddView(HeaderImage);
            //
            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.UserName);
            //
            //MainLayout.AddView(UserNameTextView);


            //Variables de UI:
            tvName = FindViewById<TextView>(Resource.Id.tvName);
            tvStatus = FindViewById<TextView>(Resource.Id.tvStatus);
            tvToken = FindViewById<TextView>(Resource.Id.tvToken);

            //Validación de la actividad:
            string mail = "";
            string pass = "";
            string AndroidId = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            validar(mail, pass, AndroidId);
        }

        public async void validar(string email, string password, string device)
        {
            var ServiceClient = new SALLab08.ServiceClient();
            var resultado = await ServiceClient.ValidateAsync(email, password, device);

            tvName.Text = resultado.Fullname;
            tvStatus.Text = resultado.Status.ToString();
            tvToken.Text = resultado.Token;
        }
    }
}

