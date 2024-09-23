using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player : GameObject
    {
        private static Player _instance;
        public static Player Instance 
        { 
            get 
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }

                return _instance;
            }
        }

        private Animation idle = new Animation(12);

        private int frame = 1;

        private string VerticalTexturePath => "Resources/dude" + frame + ".png";
        private string HorizontalTexturePath => "Resources/dudeside" + frame + ".png";

        private string arrowTexturePath = "Resources/guide.png";
        private float arrowAngle = -90f;
        private float arrowVelocity = 0f;
        private float baseArrowVelocity = 150f;

       
        private float baseVelocity = 2500f;

        private bool moving = false;
        private bool flipped = false;
        private bool sideways = false;

        public Player()
        {
            boxCollider = new BoxCollider2D(new Vector2(960f, 828f), 32f, 32f);
        }

        public void Input()
        {
            if (moving)
            {
                arrowVelocity = 0f;
                return;
            }

            if (Engine.GetKey(Keys.D))
            {
                arrowVelocity = baseArrowVelocity;

                if (Engine.GetKey(Keys.S))
                {
                    arrowVelocity = baseArrowVelocity * 2;
                }
            }
            else if (Engine.GetKey(Keys.A))
            {
                arrowVelocity = -baseArrowVelocity;

                if (Engine.GetKey(Keys.S))
                {
                    arrowVelocity = -baseArrowVelocity * 2;
                }
            }
            else
            {
                arrowVelocity = 0f;
            }

            if (Engine.GetKey(Keys.SPACE))
            {
                moving = true;

                velocity = new Vector2((float)Math.Cos(arrowAngle * Math.PI / 180f) * baseVelocity, (float)Math.Sin(arrowAngle * Math.PI / 180f) * baseVelocity);
            }
        }

        public override void Update(float deltaTime)
        {
            // Update the angle of the arrows
            arrowAngle += arrowVelocity * deltaTime;

            // Update the frame of animation
            frame = idle.UpdateAnimation(deltaTime);

            // Update the movement of the player
            if (moving) 
            {
                boxCollider.position.x += velocity.x * deltaTime;
                boxCollider.position.y += velocity.y * deltaTime;
            }

            // Check for colissions
            Colissions();
        }

        public override void Draw()
        {
            float scale = 1.02f;
            float offset = 32f;

            if (flipped)
            {
                scale = -1.02f;
                offset = -32f;
            }

            Engine.Draw(arrowTexturePath, boxCollider.position.x, boxCollider.position.y, 1f, -1920f, arrowAngle + 90f, 0f, 0f);
            Engine.Draw(PlayerTexture(), boxCollider.position.x, boxCollider.position.y, scale, scale, 0f, offset, offset);
        }

        public void ResetStats()
        {
            boxCollider = new BoxCollider2D(new Vector2(960f, 828f), 32f, 32f);

            idle = new Animation(12);

            frame = 1;

            arrowAngle = -90f;
            arrowVelocity = 0f;
            baseArrowVelocity = 150f;

            baseVelocity = 2500f;

            moving = false;
            flipped = false;
            sideways = false;
        }

        private void Colissions()
        {
            if (boxCollider.CollideWithSquare(Environment.right))
            {
                moving = false;
                sideways = true;
                flipped = false;
                boxCollider.position.x = Environment.RIGHT;
                arrowAngle = 180f;
            }
            if (boxCollider.CollideWithSquare(Environment.left))
            {
                moving = false;
                sideways = true;
                flipped = true;
                boxCollider.position.x = Environment.LEFT;
                arrowAngle = 0f;
            }
            if (boxCollider.CollideWithSquare(Environment.top))
            {
                moving = false;
                sideways = false;
                flipped = true;
                boxCollider.position.y = Environment.TOP;
                arrowAngle = 90f;
            }
            if (boxCollider.CollideWithSquare(Environment.bottom))
            {
                moving = false;
                sideways = false;
                flipped = false;
                boxCollider.position.y = Environment.BOTTOM;
                arrowAngle = -90f;
            }
        }

        private string PlayerTexture()
        {
            string texturePath;

            if (sideways)
            {
                texturePath = HorizontalTexturePath;
            }
            else
            {
                texturePath = VerticalTexturePath;
            }

            return texturePath;
        }
    }
}
