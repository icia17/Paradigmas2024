using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Menu
    {
        protected Animation menuAnimation = new Animation(4);
        protected int frame = 1;
        public virtual void Update(float deltaTime) { }
        public virtual void Draw() { }
    }
}
