using System;
using Microsoft.Phone.Tasks;

namespace WP7.Keyboard.Client
{
    public sealed class MultimediaUtility
    {
        public static void SendEmail( string body )
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask
            {
                Body = body
            };
            emailComposeTask.Show();
        }

        public static void BingSearch( string searchQuery )
        {
            SearchTask searchTask = new SearchTask
            {
                SearchQuery = searchQuery
            };
            searchTask.Show();
        }

        public static void SendSms( string body )
        {
            PhoneNumberChooserTask phoneChooseTask = new PhoneNumberChooserTask();
            EventHandler<PhoneNumberResult> temp = ( o, result ) =>
            {
                if ( result.TaskResult == TaskResult.Cancel )
                {
                    return;
                }

                SmsComposeTask smsComposeTask = new SmsComposeTask
                {
                    To = result.PhoneNumber,
                    Body = body
                };
                smsComposeTask.Show();
            };
            phoneChooseTask.Completed -= temp;
            phoneChooseTask.Completed += temp;
            phoneChooseTask.Show();
        }

        private MultimediaUtility()
        {
        }
    }
}
