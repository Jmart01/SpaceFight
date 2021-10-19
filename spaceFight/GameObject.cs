using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace spaceFight
{
    public class GameObject
    {

        public GameObject(Shape shape, Texture texture,float PosX, float PosY)
        {
            _shape = shape;
            _shape.Texture = texture;
            Position = new Vector2f(PosX, PosY);
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }


        private Shape _shape;
        public Shape Shape
        {
            get { return _shape; }
        }

        public Vector2f Position
        {
            set { _shape.Position = value; }
            get { return _shape.Position; }
        }
    }
}
