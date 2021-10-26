using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceFight
{
    public class Enemy : SpaceShip
    {
        public Enemy(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed, float ShootRate = 2) : base(shape, texture, PosX, PosY, MoveSpeed, ShootRate)
        {
            shape.Rotation = 180;
        }

        public override void Update()
        {
            base.Update();
            Fire();
            Position += GetForwardVector() * MoveSpeed * Time.DeltaTime;
        }
    }
}
