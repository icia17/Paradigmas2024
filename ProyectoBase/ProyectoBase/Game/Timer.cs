using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Timer
    {
        private static Timer _instance;
        public static Timer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Timer();
                }

                return _instance;
            }
        }

        private float timer = 41f;
        private int[] digitsList = new int[2];

        private string FirstDigitTexturePath => "Resources/number" + digitsList[0] + ".png";
        private string SecondDigitTexturePath => "Resources/number" + digitsList[1] + ".png";

        public void Update(float deltaTime)
        {
            timer -= deltaTime;

            int number = (int)timer;
            for (int i = 1; i >= 0; i--)
            {
                int lastDigit = (int)number % 10;  
                digitsList[i] = lastDigit;

                number /= 10;                   
            }

            if (timer <= 0)
            {
                timer = 41f;

                GameManager.Instance.ResetGame();
                GameManager.Instance.SetGameState(GameManager.GameState.Victory);
            }
        }

        public void Draw()
        {
            Engine.Draw(FirstDigitTexturePath, 1920f * 0.5f - 32f, 100, 2f, 2f, 0f, 32f, 64f);
            Engine.Draw(SecondDigitTexturePath, 1920f * 0.5f + 32f, 100, 2f, 2f, 0f, 32f, 64f);
        }

        public void ResetTimer()
        {
            timer = 41f;
        }
    }
}
