using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class Environment
    {
        public const float RIGHT = 1248f;
        public const float LEFT = 671f;
        public const float TOP = 251f;
        public const float BOTTOM = 828f;

        public static BoxCollider2D right = new BoxCollider2D(new Vector2(1312f, 540f), 32f, 320f);
        public static BoxCollider2D left = new BoxCollider2D(new Vector2(607f, 540f), 32f, 320f);
        public static BoxCollider2D top = new BoxCollider2D(new Vector2(960f, 187f), 320f, 32f);
        public static BoxCollider2D bottom = new BoxCollider2D(new Vector2(960f, 892f), 320f, 32f);
    }
}
