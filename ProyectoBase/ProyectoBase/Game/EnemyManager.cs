using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace Game
{
    public class EnemyManager
    {
        private static EnemyManager _instance;
        public static EnemyManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EnemyManager();
                }

                return _instance;
            }
        }

        private float spawnRate = 2f;
        private float baseSpawnRate = 2f;

        private Enemy[] enemiesActive = new Enemy[10];
        private int enemyToActivate = 0;

        private int spikeIteration = 0;

        public void Update(float deltaTime)
        {
            spawnRate -= deltaTime;

            if (spawnRate <= 0)
            {
                SpawnEnemy();
            
                spawnRate = baseSpawnRate;
            }

            for (int i = 0; i < 10; i++)
            {
                if (enemiesActive[i] == null) continue;

                if (!enemiesActive[i].LifetimeCheck())
                {
                    enemiesActive[i] = null;
                    continue;
                }

                enemiesActive[i].Update(deltaTime);

                bool colission = enemiesActive[i].CollideWithPlayer();

                if (colission) 
                {
                    Player.Instance.ResetStats();
                    GameManager.Instance.SetGameState(GameManager.GameState.Defeat);
                }
            }
        }

        public void DrawEnemies() 
        {
            foreach (Enemy enemy in enemiesActive)
            {
                if (enemy == null) continue; 

                enemy.Draw();
            }
        }
        
        public void ResetStats()
        {
            spawnRate = 2f;
            enemiesActive = new Enemy[10];
            enemyToActivate = 0;
            spikeIteration = 0;
        }

        private void SpawnEnemy()
        {
            if (enemyToActivate >= 10)
            {
                enemyToActivate = 0;
            }

            Random random = new Random();
            int randomNumber = random.Next(1, 15);

            switch (randomNumber)
            {
                case int n when n >= 12:
                    enemiesActive[enemyToActivate] = new Saw();
                    break;

                case int n when n <= 2:
                    spikeIteration++;
                    enemiesActive[enemyToActivate] = new Spikes((spikeIteration % 4) + 1);
                    break;

                default:
                    enemiesActive[enemyToActivate] = new Bullet();
                    
                    break;
            }

            enemyToActivate++;
        }
    }
}
