using System;
using System.Windows.Controls;

namespace WP7.Keyboard.Controls
{
    public class DefaultScreenControl : Control, IOutputControl
    {
        private TextBlock _screenTextBlock;
        private const string BlinkingCursor = "|";

        public DefaultScreenControl()
        {
            this.DefaultStyleKey = typeof(DefaultScreenControl);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._screenTextBlock = this.GetTemplateChild("PART_ScreenTextBlock") as TextBlock;

            if (_screenTextBlock == null)
            {
                throw new InvalidOperationException("Cannot find PART_ScreenTextBlock.");
            }
        }

        public string Text
        {
            get
            {
                return RemoveBlinkingCursor(this._screenTextBlock.Text);
            }
        }

        public void AppendToText(string symbol)
        {
            _screenTextBlock.Text = RemoveBlinkingCursor(_screenTextBlock.Text);
            _screenTextBlock.Text = AddBlinkingCursor(_screenTextBlock.Text + symbol);
        }

        public void RemoveLast()
        {
            if (this._screenTextBlock.Text.Length == 0)
            {
                return;
            }
            _screenTextBlock.Text = RemoveBlinkingCursor(_screenTextBlock.Text);
            this._screenTextBlock.Text = AddBlinkingCursor(this._screenTextBlock.Text.Remove(this._screenTextBlock.Text.Length - 1, 1));
        }

        public void Clear()
        {
            if (this._screenTextBlock.Text.Length == 0)
                return;

            while (this._screenTextBlock.Text.Length > 0)
            {
                RemoveLast();
            }

            _screenTextBlock.Text = AddBlinkingCursor(string.Empty);
        }


        private string AddBlinkingCursor(string text)
        {
            return text + BlinkingCursor;
        }

        private string RemoveBlinkingCursor(string text)
        {
            if (text.Length > 1 && text.Contains(BlinkingCursor))
                return text.Remove(text.Length - 1, 1);
            return text;
        }
    }
}
