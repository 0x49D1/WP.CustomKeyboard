using System;
using System.Security;
using System.Windows;
using BugSense;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP7.Keyboard.Client.Georgian.Modules;

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
                changeKeyboardButton.Text = "Switch to Georgian";
            }
            else
            {
                this.Keyboard.Keyboard = this.geoKeyboard;
                changeKeyboardButton.Text = "Switch to English";
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

                MessageBox.Show("Success!");
            }
            catch (SecurityException ex)
            {
                BugSenseHandler.Instance.LogError(ex);
            }
            catch (Exception ex)
            {
                BugSenseHandler.Instance.LogError(ex);
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
                    try
                    {
                        this.Keyboard.OutputControl.Clear();
                    }
                    catch (Exception ex)
                    {
                        BugSenseHandler.Instance.LogError(ex);
                    }
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative));
        }
    }
}