namespace WP7.Keyboard.KeyboardMapping
{
    public class KeyMapping
    {
        public KeyMapping( int row, string symbol )
        {
            this.Row = row;
            this.Symbol = symbol;
        }

        public int Row
        {
            get;
            set;
        }

        public string Symbol
        {
            get;
            set;
        }
    }
}
