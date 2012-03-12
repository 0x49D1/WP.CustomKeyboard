using System;
using System.Windows.Controls;

namespace WP7.Keyboard.Controls
{
    public class DefaultScreenControl : Control, IOutputControl
    {
        private TextBlock screenTextBlock;

        public DefaultScreenControl()
        {
            this.DefaultStyleKey = typeof(DefaultScreenControl);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.screenTextBlock = this.GetTemplateChild("PART_ScreenTextBlock") as TextBlock;

            if (screenTextBlock == null)
            {
                throw new InvalidOperationException("Cannot find PART_ScreenTextBlock.");
            }
        }

        public string Text
        {
            get
            {
                return this.screenTextBlock.Text;
            }
        }

        public void AppendToText(string symbol)
        {
            this.screenTextBlock.Text += symbol;
        }

        public void RemoveLast()
        {
            if (this.screenTextBlock.Text.Length == 0)
            {
                return;
            }

            this.screenTextBlock.Text = this.screenTextBlock.Text.Remove(this.screenTextBlock.Text.Length - 1, 1);
        }

        public void Clear()
        {
            if (this.screenTextBlock.Text.Length == 0)
                return;

            while (this.screenTextBlock.Text.Length > 0)
            {
                RemoveLast();
            }
        }
    }
}
