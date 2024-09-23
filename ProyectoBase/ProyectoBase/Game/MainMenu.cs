using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu : Menu
    {
        private static MainMenu _instance;
        public static MainMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainMenu();
                }

                return _instance;
            }
        }

        private string MainMenuTexturePath => "Resources/mainmenu" + frame + ".png";

        public void Input()
        {
            if (Engine.GetKey(Keys.P))
            {
                GameManager.Instance.SetGameState(GameManager.GameState.Playing);
            }
        }

        public override void Update(float deltaTime)
        {
            frame = menuAnimation.UpdateAnimation(deltaTime);
        }

        public override void Draw()
        {
            Engine.Draw(MainMenuTexturePath, 0f, 0f, 1f, 1f, 0f, 0f, 0f);
        }
    }
}
