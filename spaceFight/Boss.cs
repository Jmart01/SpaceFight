using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceFight
{
    class Boss : SpaceShip
    {
        public Boss(Shape shape, Texture texture, float PosX, float PosY, float MoveSpeed, float ShootRate = 10) : base(shape, texture, PosX, PosY, MoveSpeed, ShootRate)
        {
            Shape.Rotation = 180;
            ownerType = OwnerType.Boss;
        }

        public override void Update()
        {
            base.Update();
            Position = new Vector2f(Position.X, Position.Y + MoveSpeed * Time.DeltaTime);
            Shape.Rotation += MoveSpeed * Time.DeltaTime;
            Fire();
        }

        public override void OnCollisionEnter(GameObject other)
        {
            base.OnCollisionEnter(other);
        }
    }
}
