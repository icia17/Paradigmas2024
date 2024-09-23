using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    public class Spikes : Enemy
    {
        private string SpikeTexturePath => "Resources/spikes" + frame + ".png";
        private float textureAngle = 0f;
        private float spikeSpeed = 100f;
        private Vector2 spikeLimit;

        public Spikes(int spawnPos)
        {
            Engine.Debug("Spike spawned");

            lifeTime = 8f;

            switch (spawnPos)
            {
                case 1:
                    // TOP
                    boxCollider = new BoxCollider2D(new Vector2(1920f * 0.5f, Environment.TOP - 64f), 320f, 30f);
                    textureAngle = 180f;

                    velocity = new Vector2(0f, spikeSpeed);
                    spikeLimit = new Vector2(1920f * 0.5f, Environment.TOP);

                    break;
                case 2:
                    // BOTTOM
                    boxCollider = new BoxCollider2D(new Vector2(1920f * 0.5f, Environment.BOTTOM + 64f), 320f, 30f);
                    textureAngle = 0f;

                    velocity = new Vector2(0f, -spikeSpeed);
                    spikeLimit = new Vector2(1920f * 0.5f, Environment.BOTTOM);

                    break;
                case 3:
                    // LEFT
                    boxCollider = new BoxCollider2D(new Vector2(Environment.LEFT - 64f, 1080 * 0.5f), 30f, 320f);
                    textureAngle = 90f;

                    velocity = new Vector2(spikeSpeed, 0f);
                    spikeLimit = new Vector2(Environment.LEFT, 1080f * 0.5f);

                    break;
                default:
                    // RIGHT
                    boxCollider = new BoxCollider2D(new Vector2(Environment.RIGHT + 64f, 1080 * 0.5f), 30f, 320f);
                    textureAngle = -90f;

                    velocity = new Vector2(-spikeSpeed, 0f);
                    spikeLimit = new Vector2(Environment.RIGHT, 1080f * 0.5f);

                    break;
            }
        }

        public override void Update(float deltaTime)
        {
            lifeTime -= deltaTime;

            frame = animation.UpdateAnimation(deltaTime);

            if (lifeTime < 7f && lifeTime > 5f && boxCollider.position.Distance(spikeLimit) > 8f)
            {
                boxCollider.position += velocity * deltaTime;
            } 
            else if (boxCollider.position.Distance(spikeLimit) <= 8f || lifeTime < 5f)
            {
                boxCollider.position = spikeLimit;
            }
        }

        public override void Draw()
        {
            Engine.Draw(SpikeTexturePath,
                 boxCollider.position.x,
                 boxCollider.position.y,
                 1f, 1f,
                 textureAngle, 320f, 32f);   
        }
    }
}
