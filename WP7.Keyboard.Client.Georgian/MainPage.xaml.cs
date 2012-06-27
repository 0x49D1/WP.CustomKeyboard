using System;
using System.Security;
using System.Windows;
using BugSense;
using Microsoft.Phone.Shell;
using WP7.Keyboard.Essential;

namespace WP7.Keyboard.Client
{
    public partial class MainPage : StatefulPhoneApplicationPage
    {
        private Keyboard.Controls.Keyboard geoKeyboard;
        private Keyboard.Controls.Keyboard latinKeyboard;
        private string localClipboard = string.Empty;
        private bool isFirstLoad = true;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            latinKeyboard = new LatinKeyboard.LatinKeyboard();
            geoKeyboard = this.Keyboard.Keyboard;
        }

        //protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //}

        //protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    base.OnNavigatedFrom(e);

        //    PreserveOutputControlState(this.Keyboard.OutputControl);
        //    PreserveControlState((TextBox)this.FindName("PART_ScreenTextBox"));
        //    PreserveFocusState(this.Keyboard);
        //}

        private void EmailButtonClick(object sender, EventArgs e)
        {
            MultimediaUtility.SendEmail(Keyboard.Keyboard.Visibility == Visibility.Visible
                                            ? this.Keyboard.OutputControl.Text
                                            : this.Keyboard.OutputReadControl.Text);
        }

        private void BingSearchButtonClick(object sender, EventArgs e)
        {
            MultimediaUtility.BingSearch(Keyboard.Keyboard.Visibility == Visibility.Visible
                                             ? this.Keyboard.OutputControl.Text
                                             : this.Keyboard.OutputReadControl.Text);
        }

        private void SmsButtonClick(object sender, EventArgs e)
        {
            MultimediaUtility.SendSms(Keyboard.Keyboard.Visibility == Visibility.Visible
                                          ? this.Keyboard.OutputControl.Text
                                          : this.Keyboard.OutputReadControl.Text);
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
                localClipboard = this.Keyboard.Keyboard.Visibility == Visibility.Visible ? this.Keyboard.OutputControl.Text : this.Keyboard.OutputReadControl.Text;

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
                if (this.Keyboard.Keyboard.Visibility == Visibility.Visible)
                    this.Keyboard.OutputControl.AppendToText(localClipboard);
                else
                    this.Keyboard.OutputReadControl.AppendToText(localClipboard);

            }
        }

        private void ClearClick(object sender, EventArgs e)
        {
            if ((this.Keyboard.OutputControl.Text.Length > 0 && Keyboard.Keyboard.Visibility == Visibility.Visible)
                || (this.Keyboard.OutputReadControl.Text.Length > 0 && Keyboard.Keyboard.Visibility != Visibility.Visible))
            {
                if (MessageBox.Show("Do you really want to clear all text?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    try
                    {
                        if (Keyboard.Keyboard.Visibility == Visibility.Visible)
                            this.Keyboard.OutputControl.Clear();
                        else
                            this.Keyboard.OutputReadControl.Clear();
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