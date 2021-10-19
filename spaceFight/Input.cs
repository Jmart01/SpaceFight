using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace spaceFight
{
    public static class Input
    {
        public static bool IsKeyDown(Keyboard.Key key)
        {
            return Keyboard.IsKeyPressed(key);
        }
    }
}
