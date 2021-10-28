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
        private static Window _window;
        private static bool isKeyPressed = false;
        
        public static void SetInput(Window window)
        {
            _window = window;
            _window.KeyReleased += SwitchIsKeyBool;
        }
        public static bool IsKeyDown(Keyboard.Key key)
        {
            return Keyboard.IsKeyPressed(key);
        }
        public static bool IsKeyPressed(Keyboard.Key key)
        {
            if(!isKeyPressed && Keyboard.IsKeyPressed(key))
            {
                isKeyPressed = true;
                return true;
            }
            return false;
        }

        private static void SwitchIsKeyBool(object sender, EventArgs e)
        {
            isKeyPressed = false;
        }
    
    }
}
