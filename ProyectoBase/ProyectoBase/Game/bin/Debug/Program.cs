using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static Player player = new Player(new BoxCollider2D(new Vector2(960f, 828f), 32f, 32f), 2500f);

        static float deltaTime => DeltaTime.UpdatedDeltaTime();

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
            player.Update(deltaTime);
        }

        static void Draw()
        {
            player.Draw();

            Environment();
            
            Engine.Show();
        }

        static void Environment()
        {
            Engine.Draw("Resources/bg.png", 0f, 0f, 1f, 1f, 0f, 0f, 0f);
        }
    }
}