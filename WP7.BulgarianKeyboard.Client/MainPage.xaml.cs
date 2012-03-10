using System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WP7.Keyboard.Client
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Keyboard.Controls.Keyboard geoKeyboard;
        private Keyboard.Controls.Keyboard latinKeyboard;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            latinKeyboard = new LatinKeyboard.LatinKeyboard();
            geoKeyboard = this.Keyboard.Keyboard;
        }

        private void EmailButtonClick(object sender, EventArgs e)
        {
            MultimediaUtility.SendEmail(this.Keyboard.OutputControl.Text);
        }

        private void BingSearchButtonClick(object sender, EventArgs e)
        {
            MultimediaUtility.BingSearch(this.Keyboard.OutputControl.Text);
        }

        private void SmsButtonClick(object sender, EventArgs e)
        {
            MultimediaUtility.SendSms(this.Keyboard.OutputControl.Text);
        }

        private void ChangeKeyboardButtonClick(object sender, EventArgs e)
        {
            ApplicationBarIconButton changeKeyboardButton = sender as ApplicationBarIconButton;
            if (changeKeyboardButton == null)
            {
                return;
            }

            if (ReferenceEquals(geoKeyboard, this.Keyboard.Keyboard))
            {
                this.Keyboard.Keyboard = this.latinKeyboard;
                changeKeyboardButton.Text = "geo";
            }
            else
            {
                this.Keyboard.Keyboard = this.geoKeyboard;
                changeKeyboardButton.Text = "en";
            }
        }
    }
}