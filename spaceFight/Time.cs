﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace spaceFight
{
    public static class Time
    {
        public static void Update()
        {
            _currentFrameStartTime = _clock.ElapsedTime.AsSeconds();
            _deltaTime = _currentFrameStartTime - _prevFrameStartTime;
            _prevFrameStartTime = _currentFrameStartTime;
            _timeElapsed = _clock.ElapsedTime.AsSeconds();
        }
        private static float _deltaTime;

        public static float DeltaTime
        {
            get { return _deltaTime; }
        }

        private static float _timeElapsed;

        public static float TimeElapsed
        {
            get { return _timeElapsed; }
        }

        static Clock _clock = new Clock();

        private static float _currentFrameStartTime;
        private static float _prevFrameStartTime;

    }
}
