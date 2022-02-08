using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace DeviceDisEmailAudioExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class DeviceDisplayDemo : Activity
    {
        Button deviceinfo;
        TextView morientation;
        TextView mrotation;
        TextView mwidth;
        TextView mheight;
        TextView mdensity;
        TextView mrefreshrate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.devicedisplayInfo);
            UIReference();
            UICilckEvents();
            DisplayInfoChanged();
            DeviceDisplay.KeepScreenOn = true;
           
        }

        private void DisplayInfoChanged()
        {
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            Toast.MakeText(this,e.DisplayInfo.ToString(),ToastLength.Short).Show();
        }

        private void UICilckEvents()
        {
            deviceinfo.Click += Deviceinfo_Click;
        }

        private void Deviceinfo_Click(object sender, EventArgs e)
        {
            var devinfo = DeviceDisplay.MainDisplayInfo;

            morientation.Text = $"Orientation:{devinfo.Orientation.ToString()}";
            mrotation.Text = $"Rotation:{devinfo.Rotation.ToString()}";
            mwidth.Text = $"Width:{devinfo.Width.ToString()}";
            mheight.Text = $"Height:{devinfo.Height.ToString()}";
            mdensity.Text = $"Density:{devinfo.Density.ToString()}";
            mrefreshrate.Text = $"Refresh Rate:{devinfo.RefreshRate.ToString()}";




        }

        private void UIReference()
        {
            deviceinfo = FindViewById<Button>(Resource.Id.buttonDI);
            morientation = FindViewById<TextView>(Resource.Id.textViewDI1);
            mrotation = FindViewById<TextView>(Resource.Id.textViewDI2);
            mwidth = FindViewById<TextView>(Resource.Id.textViewDI3);
            mheight = FindViewById<TextView>(Resource.Id.textViewDI4);
            mdensity = FindViewById<TextView>(Resource.Id.textViewDI5);
            mrefreshrate = FindViewById<TextView>(Resource.Id.textViewDI6);
        }
    }
}