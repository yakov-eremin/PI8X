﻿using System;
using CosmicDefender.ObjectPool;
using SFML.System;

namespace CosmicDefender
{
    public class MultiShot : IGunShot
    {
        public void Shot()
        {
            Console.WriteLine("MultiShot");
        }

        public void Shot(Pool<Bullet> pool)
        {
            throw new NotImplementedException();
        }

        public void Shot(Pool<Bullet> pool, Vector2f coords, Vector2f rotation)
        {
            throw new NotImplementedException();
        }

        public void Shot(Pool<Bullet> pool, Vector2f coords, Vector2f rotation, Vector2f speed)
        {
            throw new NotImplementedException();
        }
    }
}