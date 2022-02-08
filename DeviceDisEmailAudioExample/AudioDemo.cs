using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DeviceDisEmailAudioExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class AudioDemo: Activity
    {
        Button Mstart;
        Button Mstop;
        Button Mresume;
        Button Mpause;
        Button Rstart;
        Button Rstop;
       
        int position;
       
        private MediaPlayer myPlayer;
       // private MediaRecorder myRecorder;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.audioDemo);
            UIReference();
            UIClickevents();
        }



        private void UIReference()
        {
            Mstart = FindViewById<Button>(Resource.Id.start);
            Mstop = FindViewById<Button>(Resource.Id.stop);
            Mpause = FindViewById<Button>(Resource.Id.pause);
            Mresume = FindViewById<Button>(Resource.Id.resume);
            Rstart = FindViewById<Button>(Resource.Id.startrec);
            Rstop = FindViewById<Button>(Resource.Id.stoprec);

        }
        private void UIClickevents()
        {
            Mstart.Click += Mstart_Click;
            Mstop.Click += Mstop_Click;
            Mpause.Click += Mpause_Click;
            Mresume.Click += Mresume_Click;
            //Rstart.Click += Rstart_Click;
            //Rstop.Click += Rstop_Click;

        }

        private void Mstart_Click(object sender, EventArgs e)
        {
            myPlayer = MediaPlayer.Create(this, Resource.Raw.mymusic);
            myPlayer.Start();
        }

        private void Mresume_Click(object sender, EventArgs e)
        {
            myPlayer.SeekTo(position);
            myPlayer.Start();
        }

        private void Mpause_Click(object sender, EventArgs e)
        {
            myPlayer.Pause();
            position = myPlayer.CurrentPosition;

        }

        private void Mstop_Click(object sender, EventArgs e)
        {
            myPlayer.Stop();

        }


        /*private void Rstop_Click(object sender, EventArgs e)
        {
            myRecorder.Stop();
        }

        [Obsolete]
       private void Rstart_Click(object sender, EventArgs e)

        {

            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/mymusic.mp3";
            if (myRecorder == null)
            {
                myRecorder = new MediaRecorder(); 
            }
            else
            {
                myRecorder.Reset();
                myRecorder.SetAudioSource(AudioSource.Default);
                myRecorder.SetOutputFormat(OutputFormat.Default);
                myRecorder.SetAudioEncoder(AudioEncoder.Default);
                myRecorder.SetOutputFile(path);
                try {
                    myRecorder.Prepare();
                    myRecorder.Start();
                }catch (Exception exception)
                {
                    Toast.MakeText(this, exception.StackTrace, ToastLength.Short).Show();
                }
               

            }
        }*/

        
     

     

    }
}