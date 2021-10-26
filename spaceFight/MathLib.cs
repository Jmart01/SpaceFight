using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Spatial.Euclidean;
using SFML.System;

namespace spaceFight
{
    public static class MathLib
    {
        public static float RatationFromVector(Vector2f vector)
        {
            Vector2D newVector = new Vector2D(vector.X, vector.Y);
            return (float)newVector.SignedAngleTo(new Vector2D(0, -1), true).Degrees;
        }
    }
}
