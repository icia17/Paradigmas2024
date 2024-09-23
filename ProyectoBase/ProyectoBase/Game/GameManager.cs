using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        public enum GameState
        {
            Menu,
            Playing,
            Victory,
            Defeat
        }

        public GameState CurrentGameState = GameState.Menu;

        public void SetGameState(GameState newState)
        {
            CurrentGameState = newState;

            switch (newState)
            {
                case GameState.Menu:
                    AudioManager.Instance.StopAudio();
                    AudioManager.Instance.PlayAudioLoop("Audio/sneaky.wav");
                    break;

                case GameState.Playing:
                    AudioManager.Instance.StopAudio();
                    AudioManager.Instance.PlayAudioLoop("Audio/pixel.wav");
                    break;

                case GameState.Victory:
                    AudioManager.Instance.StopAudio();
                    AudioManager.Instance.PlayAudioLoop("Audio/trolling.wav");
                    break;

                case GameState.Defeat:
                    AudioManager.Instance.StopAudio();
                    AudioManager.Instance.PlayAudioLoop("Audio/sad.wav");
                    break;
            }
        }

        public void ResetGame()
        {
            Timer.Instance.ResetTimer();
            EnemyManager.Instance.ResetStats();
            Player.Instance.ResetStats();
        }
    }
}
