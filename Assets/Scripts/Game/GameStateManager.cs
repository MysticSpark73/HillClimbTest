using System;

namespace HillClimb.Game
{
    public static class GameStateManager
    {
        public static GameState GameState => _currentGameState;
        public static Action<GameState> GameStateChanged;
        
        private static GameState _currentGameState = GameState.Loading;

        public static void SetGameState(GameState state)
        {
            if (Equals(_currentGameState, state)) return;
            _currentGameState = state;
            GameStateChanged?.Invoke(_currentGameState);
        }
    }
}