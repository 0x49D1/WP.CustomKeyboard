using WP7.Keyboard.KeyboardMapping;

namespace WP7.BulgarianKeyboard
{
    public class BulgarianKeyboard : Keyboard.Controls.Keyboard
    {
        protected override KeyboardContext GenerateKeyboardContext()
        {
            KeyboardContext keyboardContext = new KeyboardContext();
            keyboardContext.Rows = 3;

            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "я"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "в"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "е"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "р"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "т"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "ъ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "у"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "и"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "о"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "п"));

            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "а"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "с"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "д"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ф"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "г"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "х"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "й"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "к"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "л"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ю"));

            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ч"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "з"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ь"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ц"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ж"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "б"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "н"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "м"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ш"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "щ"));

            return keyboardContext;
        }

        protected override KeyboardContext GenerateSecondaryKeyboardContext()
        {
            return new DefaultSecondaryKeyboardContext();
        }
    }
}