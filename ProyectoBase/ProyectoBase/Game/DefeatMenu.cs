using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class DefeatMenu : Menu
    {
        private static DefeatMenu _instance;
        public static DefeatMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DefeatMenu();
                }

                return _instance;
            }
        }

        private string DefeatMenuTexturePath => "Resources/defeatmenu" + frame + ".png";

        public void Input()
        {
            if (Engine.GetKey(Keys.R))
            {
                GameManager.Instance.ResetGame();
                GameManager.Instance.SetGameState(GameManager.GameState.Playing);
            }
            else if (Engine.GetKey(Keys.M))
            {
                GameManager.Instance.ResetGame();
                GameManager.Instance.SetGameState(GameManager.GameState.Menu);
            }
        }

        public override void Update(float deltaTime)
        {
            frame = menuAnimation.UpdateAnimation(deltaTime);
        }

        public override void Draw()
        {
            Engine.Draw(DefeatMenuTexturePath, 0f, 0f, 1f, 1f, 0f, 0f, 0f);
        }
    }
}
