using WP8.Keyboard.KeyboardMapping;

namespace WP8.LatinKeyboard
{
    public class LatinKeyboard : Keyboard.Controls.Keyboard
    {
        protected override KeyboardContext GenerateKeyboardContext()
        {
            KeyboardContext keyboardContext = new KeyboardContext();
            keyboardContext.Rows = 3;

            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "q"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "w"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "e"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "r"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "t"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "y"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "u"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "i"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "o"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "p"));

            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "a"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "s"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "d"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "f"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "g"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "h"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "j"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "k"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "l"));

            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "z"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "x"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "c"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "v"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "b"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "n"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "m"));

            return keyboardContext;
        }

        protected override KeyboardContext GenerateSecondaryKeyboardContext()
        {
            return new DefaultSecondaryKeyboardContext();
        }
    }
}
