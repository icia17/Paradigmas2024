using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Saw : Enemy
    {
        private string SawTexturePath => "Resources/saw" + frame + ".png";
        private float sawSpeed = 100f;

        private Player player = Player.Instance;

        private float rotationSpeed = 10f;
        private float currentAngle = 0f;

        public Saw()
        {
            Engine.Debug("Saw spawned");

            lifeTime = 15f;

            Random random = new Random();
            float width = random.Next(0,1920);
            float height = random.Next(0, 2);

            if (height == 0)
            {
                height = 1250f;
            }
            else
            {
                height = -150f;
            }

            boxCollider = new BoxCollider2D(new Vector2(width, height), 40f, 40f);
        }

        public override void Update(float deltaTime)
        {
            lifeTime -= deltaTime;

            float deltaX = player.boxCollider.position.x - boxCollider.position.x;
            float deltaY = player.boxCollider.position.y - boxCollider.position.y;

            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance > 0)
            {
                float velocityX = (deltaX / distance) * sawSpeed;
                float velocityY = (deltaY / distance) * sawSpeed;

                velocity = new Vector2(velocityX * deltaTime, velocityY * deltaTime);

                boxCollider.position += velocity;
            }

            frame = animation.UpdateAnimation(deltaTime);

            currentAngle += rotationSpeed * deltaTime;
        }

        public override void Draw()
        {
            Engine.Draw(SawTexturePath, boxCollider.position.x, boxCollider.position.y, 1f, 1f, currentAngle, 64f, 64f);
        }
    }
}
