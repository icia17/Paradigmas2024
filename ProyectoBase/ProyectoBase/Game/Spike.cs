using Microsoft.VisualBasic.Compatibility.VB6;
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
        private string spikeTexturePath => "Resources/spikes" + frame + ".png";
        private Player player = Player.Instance;

        private Vector2 direction;

        static Random random = new Random();
        int randomNumber = random.Next(1,5);

        float rotationAngle;

        public Spike()
        {
            Engine.Debug("Spike spawned");

            lifeTime = 5f;           

            switch (randomNumber)
            {
                case 1:
                    float width = 600;
                    float height = 310;
                    boxCollider = new BoxCollider2D(new Vector2(width, height), 64f, 64f);
                    direction = new Vector2(1, 0);
                    break;

                case 2:
                    float width2 = 1400;
                    float height2 = 770;
                    boxCollider = new BoxCollider2D(new Vector2(width2, height2), 64f, 64f);
                    direction = new Vector2(-1, -0);
                    break;

                case 3:
                    float width3 = 730;
                    float height3 = 890;
                    boxCollider = new BoxCollider2D(new Vector2(width3, height3), 64f, 64f);
                    direction = new Vector2(0, -1);
                    break;
                case 4:
                    float width4 = 1190;
                    float height4 = 160;
                    boxCollider = new BoxCollider2D(new Vector2(width4, height4), 64f, 64f);
                    direction = new Vector2(0, 1);
                    break;
            }                                
        }

        public override void Update(float deltaTime)
        {
            lifeTime -= deltaTime;
            boxCollider.position += direction;
            switch (randomNumber)
            {
                case 1:
                    if (boxCollider.position.x >= 650)
                    {
                        boxCollider.position -= direction;
                    }
                    break;

                case 2:
                    if (boxCollider.position.x <=1265 )
                    {
                        boxCollider.position -= direction;
                    }
                    break;
                case 3:
                    if (boxCollider.position.y <= 850)
                    {
                        boxCollider.position -= direction;
                    }
                    break;
                case 4:
                    if (boxCollider.position.y >= 235)
                    {
                        boxCollider.position -= direction;
                    }
                    break;
            } 
        }

        public override void Draw()
        {
            switch (randomNumber)
            {
                case 1:
                    rotationAngle = 90;
                    break;

                case 2:
                    rotationAngle = -90;
                    break;
                case 4:
                    rotationAngle = -180;
                    break;
            }
            Engine.Draw(spikeTexturePath, boxCollider.position.x, boxCollider.position.y, 1f, 1f,rotationAngle, 90f, 50f);
        }
    }
}
