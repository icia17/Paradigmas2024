using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet: Enemy
    {
        private string BulletTexturePath => "Resources/bullet" + frame + ".png";
        private float textureAngle = 0f;

        private float bulletVelocity = 250f;

        public Bullet()
        {
            Engine.Debug("Bullet spawned");

            lifeTime = 15f;

            Random random = new Random();
            int spawnPos = random.Next(1, 5);

            int randomWidth = random.Next((int)Environment.LEFT, (int)Environment.RIGHT);
            int randomHeight = random.Next((int)Environment.TOP, (int)Environment.BOTTOM);

            switch (spawnPos)
            {
                case 1:
                    // TOP
                    boxCollider = new BoxCollider2D(new Vector2(randomWidth, -32f), 32f, 50f);
                    textureAngle = 180f;

                    velocity = new Vector2(0f, bulletVelocity);

                    break;
                case 2:
                    // BOTTOM

                    boxCollider = new BoxCollider2D(new Vector2(randomWidth, 1080f + 32f), 32f, 50f);
                    textureAngle = 0f;

                    velocity = new Vector2(0f, -bulletVelocity);

                    break;
                case 3:
                    // LEFT
                    boxCollider = new BoxCollider2D(new Vector2(-32f, randomHeight), 50f, 32f);
                    textureAngle = 90f;

                    velocity = new Vector2(bulletVelocity, 0f);

                    break;
                case 4:
                    // RIGHT
                    boxCollider = new BoxCollider2D(new Vector2(1920f + 32f, randomHeight), 50f, 32f);
                    textureAngle = -90f;

                    velocity = new Vector2(-bulletVelocity, 0f);

                    break;
            }
        }

        public override void Update(float deltaTime)
        {
            lifeTime -= deltaTime;

            boxCollider.position += velocity * deltaTime;

            frame = animation.UpdateAnimation(deltaTime);
        }

        public override void Draw()
        {
            Engine.Draw(BulletTexturePath,
                boxCollider.position.x,
                boxCollider.position.y,
                2f, 2f,
                textureAngle, 32f, 64f);
        }
    }
}
