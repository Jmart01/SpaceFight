using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace spaceFight
{
    public class SpaceShip : GameObject
    {

        public enum OwnerType
        {
            Player,
            Enemy,
            Boss
        }
        OwnerType _ownerType;

        public OwnerType ownerType
        {
            set { _ownerType = value; }
            get { return _ownerType; }
        }
        public SpaceShip(Shape shape,Texture texture, float PosX, float PosY, float MoveSpeed, float ShootRate = 10) : base(shape, texture, PosX, PosY)
        {
            _moveSpeed = MoveSpeed;
            this.ShootRate = ShootRate;
            _Cooldown = 1f/ShootRate;
        }

        private float _moveSpeed;
        public float MoveSpeed
        {
            protected set { _moveSpeed = value; }
            get { return +_moveSpeed; }
        }

        public override void Update()
        {
            base.Update();
            _cooldownCounter += Time.DeltaTime;
        }

        virtual public void Fire()
        {
            Console.WriteLine("SHooting my load");
            if (CanFire())
            {
                SpawnProjectile();
                _cooldownCounter = 0;
                
            }
        }

        void SpawnProjectile()
        {
            Vector2f ForwardVector = GetForwardVector();
            Vector2f SpawnPos =Position + ForwardVector * Shape.GetLocalBounds().Height;
            Projectile newProjectile = new Projectile(new RectangleShape(new Vector2f(50,50)),AssetManager.GetTexture("Projectile.png"), SpawnPos.X,SpawnPos.Y, ForwardVector * MoveSpeed *2);
            newProjectile.Owner = this;
        }

        

        float _ShootRate = 3f;
        float _Cooldown;
        float _cooldownCounter;

        public float ShootRate
        {
            set { _ShootRate = value;
                _Cooldown = 1f/ _ShootRate;
            }
            get { return _ShootRate;}
        }

        bool CanFire()
        {
            return _cooldownCounter >= _Cooldown;
        }
        public override void OnCollisionEnter(GameObject other)
        {
            if(other.Owner != this)
            {
                Projectile otherAsProjectile = other as Projectile;
                if (otherAsProjectile != null)
                {
                    if (this.ownerType == OwnerType.Enemy)
                    {
                        Program.GetGameInstance().DecreseEnemyCountToSpawnBoss();
                    }
                    Destroy();
                }
            }
        }
    }
}
