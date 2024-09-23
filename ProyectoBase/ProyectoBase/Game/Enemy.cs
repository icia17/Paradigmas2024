using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Enemy : GameObject
    {
        protected float lifeTime;

        protected Animation animation = new Animation(4);
        protected int frame = 1;

        public bool LifetimeCheck() 
        {
            if (lifeTime <= 0f)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CollideWithPlayer() 
        {
            if (boxCollider.CollideWithSquare(Player.Instance.boxCollider)) 
            {
                return true;
            }

            return false;
        }
    }
}
