using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class VictoryMenu : Menu
    {
        private static VictoryMenu _instance;
        public static VictoryMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VictoryMenu();
                }

                return _instance;
            }
        }

        private string VictoryMenuTexturePath => "Resources/victorymenu" + frame + ".png";

        private float mainMenuCD = 7.5f;

        public override void Update(float deltaTime)
        {
            frame = menuAnimation.UpdateAnimation(deltaTime);

            mainMenuCD -= deltaTime;

            if (mainMenuCD <= 0)
            {
                mainMenuCD = 7.5f;

                GameManager.Instance.SetGameState(GameManager.GameState.Menu);
            }
        }

        public override void Draw()
        {
            Engine.Draw(VictoryMenuTexturePath, 0f, 0f, 1f, 1f, 0f, 0f, 0f);
        }
    }
}
