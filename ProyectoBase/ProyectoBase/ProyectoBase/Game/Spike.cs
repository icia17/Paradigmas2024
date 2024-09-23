using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    public class Spike : Enemy
    {
        private float spawnTimer;
        private float spawnInterval = 1.0f;

        private Random random;

        public Spike()
        {
            Engine.Debug("Spike spawned");
            // SpawnSpike();
        }

        public override void Update(float deltaTime)
        {

        }

        private void SpawnSpike()
        {
            Vector2 spawnPosition;

            // Generate a random Y position between the top and bottom of the screen
            float randomY = (float)random.NextDouble() * (Environment.TOP - Environment.BOTTOM);

            // Randomly decide if the spike should spawn on the left or right wall
            bool isOnRightSide = random.Next(0, 2) == 1;

            if (isOnRightSide)
            {
                // Spawn on the right wall
                spawnPosition = new Vector2(Environment.RIGHT, randomY);
            }
            else
            {
                // Spawn on the left wall
                spawnPosition = new Vector2(Environment.LEFT, randomY);
            }

            boxCollider.position = spawnPosition;
        }

        public override void Draw()
        {
            Engine.Draw("Resources/Spike.png",
                 boxCollider.position.x,
                 boxCollider.position.y,
                 0.5f, 0.5f, // Assuming scaling factors (adjust if necessary)
                 0f, 0f, // Pivot point for the rotation (can be adjusted)
                 0f);    // Layer or depth (optional, adjust depending on your engine)
        }
    }
}
