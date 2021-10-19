﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace spaceFight
{
    public static class AssetManager
    {
        static public Texture GetTexture(string textureName)
        {
            if(textures.TryGetValue(textureName,out Texture texture))
            {
                return texture;
            }

            Texture newTexture = new Texture("./textures/" + textureName);
            textures.Add(textureName, newTexture);
            return newTexture;
        }


        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
    }
}
