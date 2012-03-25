using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace WP7.Keyboard.Essential
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
                if (this.State.ContainsKey(STATE_PRESERVED_STRING))
                    return (bool)this.State[STATE_PRESERVED_STRING];
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

            this.State[STATE_PRESERVED_STRING] = true;
        }

        private void PreserveCheckBoxState(CheckBox checkBox)
        {
            this.State[checkBox.Name + ".IsChecked"] = checkBox.IsChecked;
        }

        private void PreserveTextBoxState(TextBox textBox)
        {
            this.State[textBox.Name + ".Text"] = textBox.Text;
            this.State[textBox.Name + ".SelectionStart"] = textBox.SelectionStart;
            this.State[textBox.Name + ".SelectionLength"] = textBox.SelectionLength;
        }

        protected void PreserveFocusState(FrameworkElement parent)
        {
            Control focusedControl = FocusManager.GetFocusedElement() as Control;
            if (focusedControl == null)
            {
                this.State["FocusedControlName"] = null;
            }
            else
            {
                Control controlWithFocus = parent.FindName(focusedControl.Name) as Control;

                if (controlWithFocus == null)
                    this.State["FocusedControlName"] = null;
                else
                    this.State["FocusedControlName"] = focusedControl.Name;
            }
        }

        protected void PreserveTextBlockState(TextBlock textBlock)
        {
            this.State[textBlock.Name + ".Text"] = textBlock.Text;
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

        protected void RestoreFocusState(FrameworkElement parent)
        {
            if (this.State["FocusedControlName"] == null || !(this.State["FocusedControlName"] is string))
                return;

            Control focusedControl = parent.FindName(this.State["FocusedControlName"] as string) as Control;
            if (focusedControl != null)
                focusedControl.Focus();
        }

        #endregion

        private T TryGetValue<T>(string name, T defaultValue)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name cant be null. We cant find object's state");
            if (!this.State.ContainsKey(name))
                return defaultValue;

            return (T)this.State[name];
        }
    }
}
