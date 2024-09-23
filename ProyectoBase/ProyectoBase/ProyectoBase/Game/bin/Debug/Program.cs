using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static Player player = Player.Instance;
        static EnemyManager enemyManager = EnemyManager.Instance;

        static float deltaTime;


        static void Main(string[] args)
        {
            Engine.Initialize();

            while (true)
            {
                Clear();
                Input();
                Update();
                Draw();
            }
        }

        static void Clear()
        {
            Engine.Clear();
        }

        static void Input()
        {
            player.Input();
        }

        static void Update()
        {
            deltaTime = DeltaTime.UpdatedDeltaTime();

            player.Update(deltaTime);

            enemyManager.Update(deltaTime);
        }

        static void Draw()
        {
            player.Draw();

            Environment(); 
            
            enemyManager.DrawEnemies();
            
            Engine.Show();
        }

        static void Environment()
        {
            Engine.Draw("Resources/bg.png", 0f, 0f, 1f, 1f, 0f, 0f, 0f);
        }
    }
}