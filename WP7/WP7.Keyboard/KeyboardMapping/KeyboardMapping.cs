using System.Collections.Generic;
using System.Linq;

namespace WP7.Keyboard.KeyboardMapping
{
    public class KeyboardMapping : List<KeyMapping>
    {
        public List<KeyMapping> GetKeyMappingsByRow( int row )
        {
            return this.Where( k => k.Row == row ).ToList();
        }
    }
}
