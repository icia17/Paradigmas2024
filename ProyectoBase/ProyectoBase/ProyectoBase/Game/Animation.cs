using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        private int fps;
        private int currentFrame = 1;
        private float nextFrame;
        private float timeLeft;

        public Animation(int fps)
        {
            this.fps = fps;

            nextFrame = 1f / fps;
            timeLeft = nextFrame;
        }

        public int UpdateAnimation(float deltaTime)
        {
            timeLeft -= deltaTime;

            if (timeLeft <= 0) 
            {
                timeLeft = nextFrame;
                currentFrame++;

                if (currentFrame > fps)
                {
                    currentFrame = 1;
                }
            }

            return currentFrame;
        }
    }
}
