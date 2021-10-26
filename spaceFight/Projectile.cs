using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace spaceFight
{
    public class Projectile : GameObject
    {
        private float _projectileSpeed;
        public float ProjectileSpeed
        {
            set { _projectileSpeed = value; }
            get { return _projectileSpeed; }
        }
        public Projectile(Shape shape, Texture texture, float PosX, float PosY, Vector2f Velocity) : base(shape, texture, PosX, PosY)
        {
            _velocity = Velocity;
            float rotation = MathLib.RatationFromVector(_velocity);
            shape.Rotation = rotation;
        }
        Vector2f _velocity;
        public override void Update()
        {
            base.Update();
            Position += _velocity * Time.DeltaTime;
        }

        public override void OnCollisionEnter(GameObject other)
        {
            if(other.Owner != this.Owner)
            {
                if(other != Owner)
                {
                    Destroy();
                    //Console.WriteLine($"{Owner}, {other.Owner}");
                }
            }
        }
    }
}
