using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DeviceDisEmailAudioExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class EmailDemo: Activity
    {
        private EditText textTo;
        private EditText textSubject;
        private EditText textBody;
        private EditText textCC;
        private EditText textBCC;
        private Button buttonSend;
        private Button buttonAttachment;
        private List<String> recipientsList;
        private List<String> CCList;
        private List<String> BCCList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.emailDemo);
            UIReference();
            UIClickEvents();
        }

        private void UIClickEvents()
        {
            buttonSend.Click += ButtonSend_ClickAsync;
            buttonAttachment.Click += ButtonAttachment_Click;
        }

        private async void ButtonAttachment_Click(object sender, EventArgs e)
        {
            EmailMessage emsg = GetEmailMessage();
            var fn = "Friend.txt";
            var file = Path.Combine(FileSystem.CacheDirectory, fn);
            File.WriteAllText(file, "There are six firend who live happly in their world");

            emsg.Attachments.Add(new EmailAttachment(file));
            try
            {
                await Email.ComposeAsync(emsg);
            }
            catch (FeatureNotSupportedException fns)
            {

                Toast.MakeText(this,fns.StackTrace,ToastLength.Short).Show();
            
            }
            catch (Exception exception)
            {

                Toast.MakeText(this, exception.StackTrace, ToastLength.Short).Show();

            }


        }

        private async void ButtonSend_ClickAsync(object sender, EventArgs e)
        {
            EmailMessage emsg = GetEmailMessage();
            try {

                await Email.ComposeAsync(emsg);

            }
            catch (FeatureNotSupportedException fns)
            {

                Toast.MakeText(this, fns.StackTrace, ToastLength.Short).Show();

            }
            catch (Exception exception)
            {

                Toast.MakeText(this, exception.StackTrace, ToastLength.Short).Show();

            }

        }

        private EmailMessage GetEmailMessage()
        {
             recipientsList= new List<string>();
             CCList = new List<string>();
             BCCList = new List<string>();
             recipientsList.AddRange(textTo.Text.Trim().Split(""));
             CCList.AddRange(textCC.Text.Trim().Split(""));
             BCCList.AddRange(textBCC.Text.Trim().Split(""));

            string subject = textSubject.Text;
            string body = textBody.Text;

            EmailMessage emsg = new EmailMessage
            {
                To = recipientsList,
                Subject = subject,
                Body = body,
                Cc = CCList,
                Bcc= BCCList

            };
            return emsg;


        }

        private void UIReference()
        {
            textTo = FindViewById<EditText>(Resource.Id.editText1);
            textSubject = FindViewById<EditText>(Resource.Id.editText2);
            textBody = FindViewById<EditText>(Resource.Id.editText3);
            textCC = FindViewById<EditText>(Resource.Id.editText4);
            textBCC= FindViewById<EditText>(Resource.Id.editText5);
            buttonSend = FindViewById<Button>(Resource.Id.buttonSE);
            buttonAttachment = FindViewById<Button>(Resource.Id.buttonAA);
        }
    }
}