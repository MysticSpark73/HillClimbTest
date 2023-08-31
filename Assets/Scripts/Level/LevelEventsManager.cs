using System;

namespace HillClimb.Level
{
    public static class LevelEventsManager
    {
        public static Action LevelReady;
        public static Action LevelFailed;
        public static Action LevelComplete;
        public static Action LevelRestart;
    }
}