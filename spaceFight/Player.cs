using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;


namespace spaceFight
{
    class Player : SpaceShip
    {
        public Player(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed) : base(shape, texture, PosX, PosY, MoveSpeed)
        {
        }


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
        }


    }
}
