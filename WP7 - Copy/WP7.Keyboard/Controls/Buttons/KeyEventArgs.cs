using System;

namespace WP7.Keyboard.Controls
{
    public class KeyEventArgs : EventArgs
    {
        public KeyEventArgs( bool isInShiftMode, string symbol )
        {
            this.IsInShiftMode = isInShiftMode;
            this.Symbol = symbol;
        }

        public bool IsInShiftMode
        {
            get;
            protected set;
        }

        public string Symbol
        {
            get;
            protected set;
        }
    }
}
