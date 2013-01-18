using System.Collections.Generic;
using WP8.Keyboard.KeyboardMapping;

namespace WP8.GeorgianKeyboard
{
    public class GeorgianKeyboard : Keyboard.Controls.Keyboard
    {
        protected override KeyboardContext GenerateKeyboardContext()
        {
            KeyboardContext keyboardContext = new KeyboardContext();
            keyboardContext.Rows = 3;

            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "ქ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "წ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "ე"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "რ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "ტ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "ყ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "უ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "ი"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "ო"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(0, "პ"));

            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ა"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ს"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "დ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ფ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "გ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ჰ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ჯ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "კ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(1, "ლ"));

            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ზ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ხ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ც"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ვ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ბ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "ნ"));
            keyboardContext.KeyboardMapping.Add(new KeyMapping(2, "მ"));

            ToUpperReplacement = new Dictionary<string, string>();
            ToUpperReplacement.Add("წ","ჭ");
            ToUpperReplacement.Add("რ","ღ");
            ToUpperReplacement.Add("ტ","თ");
            ToUpperReplacement.Add("ს","შ");
            ToUpperReplacement.Add("ჯ","ჟ");
            ToUpperReplacement.Add("ზ","ძ");
            ToUpperReplacement.Add("ც","ჩ");
            ToUpperReplacement.Add("ნ","N");

            return keyboardContext;
        }

        protected override KeyboardContext GenerateSecondaryKeyboardContext()
        {
            return new DefaultSecondaryKeyboardContext();
        }
    }
}
