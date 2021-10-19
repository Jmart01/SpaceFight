using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace spaceFight
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Game game = new Game(720, 1240, "Space Fight");
            game.AddGameObject(new Player(new RectangleShape(new Vector2f(100, 100)), AssetManager.GetTexture("Bolbi.png"), 100, 100, 400));
            game.Run();
        }
    }
}
