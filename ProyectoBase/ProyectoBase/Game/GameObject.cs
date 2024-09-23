using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject
    {
        public BoxCollider2D boxCollider;
        protected Vector2 velocity;

        public abstract void Update(float deltaTime);

        public abstract void Draw();
    }
}
