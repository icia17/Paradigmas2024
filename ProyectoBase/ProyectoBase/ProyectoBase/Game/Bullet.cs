using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet: Enemy
    {
        public Bullet()
        {
            Engine.Debug("Bullet spawned");
        }

        public override void Update(float deltaTime)
        {

        }

        public override void Draw()
        {
            
        }
    }
}
