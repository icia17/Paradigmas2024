using System;

namespace Game
{
    public static class DeltaTime
    {
        private static float _deltaTime;

        private static DateTime lastTime = DateTime.Now;

        public static float UpdatedDeltaTime()
        {
            DateTime currentTime = DateTime.Now;

            _deltaTime = (float)(currentTime - lastTime).TotalSeconds;

            lastTime = currentTime;

            return _deltaTime;
        }
    }
}