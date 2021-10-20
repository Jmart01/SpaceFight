using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace spaceFight
{
    class Projectile : GameObject
    {
        private float _projectileSpeed;
        public float ProjectileSpeed
        {
            set { _projectileSpeed = value; }
            get { return _projectileSpeed; }
        }
        public Projectile(Shape shape, Texture texture, float PosX, float PosY, float projectileSpeed) : base(shape, texture, PosX, PosY)
        {
            this._projectileSpeed = projectileSpeed;
        }

        public override void Update()
        {
            base.Update();
            Position = new Vector2f(Position.X, Position.Y - ProjectileSpeed * Time.DeltaTime);
        }
    }
}
