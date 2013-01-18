namespace WP8.Keyboard.KeyboardMapping
{
    public class KeyboardContext
    {
        public KeyboardContext()
        {
            this.KeyboardMapping = new KeyboardMapping();
        }

        public int Rows
        {
            get;
            set;
        }

        public KeyboardMapping KeyboardMapping
        {
            get;
            set;
        }
    }
}
