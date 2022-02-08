using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace DeviceDisEmailAudioExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button myDeviceDisInfo;
        Button myEmail;
        Button myAudio;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            myDeviceDisInfo = FindViewById<Button>(Resource.Id.button1);
            myEmail = FindViewById<Button>(Resource.Id.button2);
            myAudio = FindViewById<Button>(Resource.Id.button3);


            myDeviceDisInfo.Click += MyDeviceDisInfo_Click;
            myEmail.Click += MyEmail_Click;
            myAudio.Click += MyAudio_Click;
        }

        private void MyAudio_Click(object sender, System.EventArgs e)
        {
            Intent k = new Intent(Application.Context, typeof(AudioDemo));
            StartActivity(k);
        }

        private void MyEmail_Click(object sender, System.EventArgs e)
        {
            Intent j = new Intent(Application.Context, typeof(EmailDemo));
            StartActivity(j);
        }

        private void MyDeviceDisInfo_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(Application.Context, typeof(DeviceDisplayDemo));
            StartActivity(i);
        }

      

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}