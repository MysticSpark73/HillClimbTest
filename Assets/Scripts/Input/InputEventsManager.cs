using System;

namespace HillClimb.Input
{
    public static class InputEventsManager
    {
        public static Action<bool> GasPedalPressed;
        public static Action<bool> BreakPedalPressed;
    }
}