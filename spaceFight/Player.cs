using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;
using System.Timers;

namespace spaceFight
{
    class Player : SpaceShip
    {
        private Timer aTimer;
        private static Game _Game;
        public Player(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed, Game game/* float projectileSpawnRate*/) : base(shape, texture, PosX, PosY, MoveSpeed)
        {
            _Game = game;
            //aTimer = new System.Timers.Timer(projectileSpawnRate * 1000);
            //aTimer.Elapsed += OnTimedEvent;
    
            //aTimer.AutoReset = true;
            //aTimer.Enabled = false;
        }

        /*private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(Input.IsKeyDown(Keyboard.Key.Space))
            {
                Console.WriteLine("I am getting turnt");
                _Game.AddGameObject(new Projectile(new RectangleShape(new Vector2f(50, 50)), AssetManager.GetTexture("Projectile.png"), (int)Shape.Position.X + 10, (int)Shape.Position.Y, 400));
            }
        }*/

        public override void Update()
        {
            base.Update();
            if(Input.IsKeyDown(Keyboard.Key.W))
            {
                Position = new Vector2f(Position.X, Position.Y - MoveSpeed * Time.DeltaTime);
            }
            if (Input.IsKeyDown(Keyboard.Key.S))
            {
                Position = new Vector2f(Position.X, Position.Y + MoveSpeed * Time.DeltaTime);
            }
            if (Input.IsKeyDown(Keyboard.Key.A))
            {
                Position = new Vector2f(Position.X - MoveSpeed * Time.DeltaTime, Position.Y);
            }
            if (Input.IsKeyDown(Keyboard.Key.D))
            {
                Position = new Vector2f(Position.X + MoveSpeed * Time.DeltaTime, Position.Y);
            }
            /*if(Input.IsKeyPressed(Keyboard.Key.Space))
            {
                aTimer.Enabled = true;  
            }
            */
            if(Input.IsKeyDown(Keyboard.Key.Space))
            {
                Fire();
            }
            if(Input.IsKeyDown(Keyboard.Key.E))
            {
                Shape.Rotation += Time.DeltaTime *70;
            }
            if(Input.IsKeyDown(Keyboard.Key.Q))
            {
                Shape.Rotation += Time.DeltaTime * -50;
            }
        }



    }
}
