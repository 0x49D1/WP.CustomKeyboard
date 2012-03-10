namespace WP7.Keyboard.KeyboardMapping
{
    public class DefaultSecondaryKeyboardContext : KeyboardContext
    {
        public DefaultSecondaryKeyboardContext()
        {
            this.Rows = 4;

            this.KeyboardMapping.Add( new KeyMapping( 0, "1" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "2" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "3" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "4" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "5" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "6" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "7" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "8" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "9" ) );
            this.KeyboardMapping.Add( new KeyMapping( 0, "0" ) );

            this.KeyboardMapping.Add( new KeyMapping( 1, "!" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "@" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "#" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "$" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "%" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "^" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "&" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "*" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, "(" ) );
            this.KeyboardMapping.Add( new KeyMapping( 1, ")" ) );

            this.KeyboardMapping.Add( new KeyMapping( 2, "`" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "~" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "_" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "-" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "+" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "=" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "<" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, ">" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "[" ) );
            this.KeyboardMapping.Add( new KeyMapping( 2, "]" ) );

            this.KeyboardMapping.Add( new KeyMapping( 3, "?" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, "|" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, "\\" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, "/" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, ":" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, ";" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, "'" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, "\"" ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, "," ) );
            this.KeyboardMapping.Add( new KeyMapping( 3, "." ) );
        }
    }
}
