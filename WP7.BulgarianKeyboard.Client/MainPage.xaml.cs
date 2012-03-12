using System;
using System.Security;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WP7.Keyboard.Client
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Keyboard.Controls.Keyboard geoKeyboard;
        private Keyboard.Controls.Keyboard latinKeyboard;

        private string localClipboard = string.Empty;

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
            ApplicationBarMenuItem changeKeyboardButton = sender as ApplicationBarMenuItem;
            if (changeKeyboardButton == null)
            {
                return;
            }

            if (ReferenceEquals(geoKeyboard, this.Keyboard.Keyboard))
            {
                this.Keyboard.Keyboard = this.latinKeyboard;
                changeKeyboardButton.Text = "Switch to GEO";
            }
            else
            {
                this.Keyboard.Keyboard = this.geoKeyboard;
                changeKeyboardButton.Text = "Switch to EN";
            }
        }

        private void CopyTextButtonClick(object sender, EventArgs e)
        {
            try
            {
                localClipboard = this.Keyboard.OutputControl.Text;
                Clipboard.SetText(localClipboard);
                ApplicationBarMenuItem item = (ApplicationBarMenuItem)ApplicationBar.MenuItems[1];
                if (item != null)
                    item.IsEnabled = true;
                MessageBox.Show("Copy success!");
            }
            catch (SecurityException ex)
            {
                MessageBox.Show("Clipboard not permitted");
            }
        }

        private void PasteClick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                this.Keyboard.OutputControl.AppendToText(localClipboard);
            }
        }

        private void ClearClick(object sender, EventArgs e)
        {
            if (this.Keyboard.OutputControl.Text.Length > 0)
            {
                if (MessageBox.Show("Do you really want to clear all text?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    while (this.Keyboard.OutputControl.Text.Length > 0)
                    {
                        this.Keyboard.OutputControl.RemoveLast();
                    }
                }
            }
        }
    }
}