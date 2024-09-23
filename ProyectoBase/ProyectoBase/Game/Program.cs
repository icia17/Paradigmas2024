using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    class Program
    {
        static GameManager gameManager = GameManager.Instance;
        static EnemyManager enemyManager = EnemyManager.Instance;
        static MainMenu mainMenu = MainMenu.Instance;
        static VictoryMenu victoryMenu = VictoryMenu.Instance;
        static DefeatMenu defeatMenu = DefeatMenu.Instance;
        static Timer timer = Timer.Instance;
        static Player player = Player.Instance;
        static AudioManager audioManager = AudioManager.Instance;

        static float deltaTime;

        static void Main(string[] args)
        {
            Engine.Initialize();

            AudioManager.Instance.PlayAudioLoop("Audio/sneaky.wav");

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
            switch (gameManager.CurrentGameState)
            {
                case GameManager.GameState.Playing:
                    player.Input();
                    break;

                case GameManager.GameState.Menu:
                    mainMenu.Input();
                    break;

                case GameManager.GameState.Defeat:
                    defeatMenu.Input();
                    break;

                default:
                    break;
            }
        }

        static void Update()
        {
            deltaTime = DeltaTime.UpdatedDeltaTime();

            switch (gameManager.CurrentGameState)
            {
                case GameManager.GameState.Playing:
                    player.Update(deltaTime);
                    enemyManager.Update(deltaTime);
                    timer.Update(deltaTime);
                    break;

                case GameManager.GameState.Menu:
                    mainMenu.Update(deltaTime);
                    break;

                case GameManager.GameState.Defeat:
                    defeatMenu.Update(deltaTime);
                    break;

                default:
                    victoryMenu.Update(deltaTime);
                    break;
            }
        }

        static void Draw()
        {
            switch (gameManager.CurrentGameState)
            {
                case GameManager.GameState.Playing:
                    player.Draw();
                    Environment();
                    enemyManager.DrawEnemies();
                    timer.Draw();
                    break;

                case GameManager.GameState.Menu:
                    mainMenu.Draw();
                    break;

                case GameManager.GameState.Defeat:
                    defeatMenu.Draw();
                    break;

                default:
                    victoryMenu.Draw();
                    break;
            }
            
            Engine.Show();
        }

        static void Environment()
        {
            Engine.Draw("Resources/bg.png", 0f, 0f, 1f, 1f, 0f, 0f, 0f);
        }
    }
}