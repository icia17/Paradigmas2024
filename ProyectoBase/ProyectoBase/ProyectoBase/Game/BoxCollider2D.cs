using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct BoxCollider2D
    {
        public Vector2 position;
        float sizeX;
        float sizeY;

        public BoxCollider2D(Vector2 position, float sizeX, float sizeY)
        {
            this.position = position;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public bool CollideWithSquare(BoxCollider2D other)
        {
            bool collision =
                position.x - sizeX < other.position.x + other.sizeX && 
                position.x + sizeX > other.position.x - other.sizeX && 
                position.y - sizeY < other.position.y + other.sizeY && 
                position.y + sizeY > other.position.y - other.sizeY;   

            return collision;
        }
    }
}
