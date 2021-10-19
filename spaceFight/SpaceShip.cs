using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace spaceFight
{
    public class SpaceShip : GameObject
    {
        public SpaceShip(Shape shape,Texture texture, float PosX, float PosY, float MoveSpeed) : base(shape, texture, PosX, PosY)
        {
            _moveSpeed = MoveSpeed;
        }

        private float _moveSpeed;
        public float MoveSpeed
        {
            protected set { _moveSpeed = value; }
            get { return +_moveSpeed; }
        }
    }
}
