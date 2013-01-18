using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP8.Keyboard.Controls;

namespace WP8.Keyboard.Essential
{
    public class StatefulPhoneApplicationPage : PhoneApplicationPage
    {
        private const string STATE_PRESERVED_STRING = "StatePreserved";

        public StatefulPhoneApplicationPage()
        {
            IsNewPageInstance = true;
        }

        #region Properties

        protected bool IsNewPageInstance { get; private set; }

        protected bool IsStatePreserved
        {
            get
            {
                if (PhoneApplicationService.Current.State.ContainsKey(STATE_PRESERVED_STRING))
                    return (bool)PhoneApplicationService.Current.State[STATE_PRESERVED_STRING];
                return false;
            }
        }

        #endregion

        #region Preservation Methods

        protected void PreserveControlState(Control control)
        {
            if (control is TextBox)
                PreserveTextBoxState(control as TextBox);
            else if (control is CheckBox)
                PreserveCheckBoxState(control as CheckBox);

            PhoneApplicationService.Current.State[STATE_PRESERVED_STRING] = true;
        }

        private void PreserveCheckBoxState(CheckBox checkBox)
        {
            PhoneApplicationService.Current.State[checkBox.Name + ".IsChecked"] = checkBox.IsChecked;
        }

        private void PreserveTextBoxState(TextBox textBox)
        {
            PhoneApplicationService.Current.State[textBox.Name + ".Text"] = textBox.Text;
            PhoneApplicationService.Current.State[textBox.Name + ".SelectionStart"] = textBox.SelectionStart;
            PhoneApplicationService.Current.State[textBox.Name + ".SelectionLength"] = textBox.SelectionLength;
        }

        protected void PreserveOutputControlState(IOutputControl outputControl)
        {
            PhoneApplicationService.Current.State["OutputControl.Text"] = outputControl.Text;
        }

        protected void PreserveFocusState(FrameworkElement parent)
        {
            Control focusedControl = FocusManager.GetFocusedElement() as Control;
            if (focusedControl == null)
            {
                PhoneApplicationService.Current.State["FocusedControlName"] = null;
            }
            else
            {
                Control controlWithFocus = parent.FindName(focusedControl.Name) as Control;

                if (controlWithFocus == null)
                    PhoneApplicationService.Current.State["FocusedControlName"] = null;
                else
                    PhoneApplicationService.Current.State["FocusedControlName"] = focusedControl.Name;
            }
        }

        protected void PreserveTextBlockState(TextBlock textBlock)
        {
            if (textBlock != null)
                PhoneApplicationService.Current.State[textBlock.Name + ".Text"] = textBlock.Text;
        }

        #endregion

        #region Restoration Methods

        protected void RestoreControlState(Control control)
        {
            if (control is TextBox)
                RestoreTextBoxState(control as TextBox, string.Empty);
            else if (control is CheckBox)
                RestoreCheckBoxState(control as CheckBox);
        }

        private void RestoreCheckBoxState(CheckBox checkBox, bool defaultValue = false)
        {
            checkBox.IsChecked = TryGetValue<bool>(checkBox.Name + ".IsChecked", defaultValue);
        }

        private void RestoreTextBoxState(TextBox textBox, string defaultValue = "")
        {
            textBox.Text = TryGetValue<string>(textBox.Name + ".Text", defaultValue);
            textBox.SelectionStart = TryGetValue<int>(textBox.Name + ".SelectionStart", textBox.Text.Length);
            textBox.SelectionLength = TryGetValue<int>(textBox.Name + ".SelectionLength", 0);
        }

        protected void RestoreTextBlockState(TextBlock textBlock)
        {
            textBlock.Text = TryGetValue<string>(textBlock.Name + ".Text", string.Empty);
        }

        protected void RestoreOutputControlState(IOutputControl outputControl)
        {
            if (outputControl != null)
                outputControl.AppendToText(TryGetValue<string>("OutputControl.Text", string.Empty));
        }

        protected void RestoreFocusState(FrameworkElement parent)
        {
            if (PhoneApplicationService.Current.State["FocusedControlName"] == null || !(PhoneApplicationService.Current.State["FocusedControlName"] is string))
                return;

            Control focusedControl = parent.FindName(PhoneApplicationService.Current.State["FocusedControlName"] as string) as Control;
            if (focusedControl != null)
                focusedControl.Focus();
        }

        #endregion

        private T TryGetValue<T>(string name, T defaultValue)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name cant be null. We cant find object's state");
            if (!PhoneApplicationService.Current.State.ContainsKey(name))
                return defaultValue;

            return (T)PhoneApplicationService.Current.State[name];
        }
    }
}
