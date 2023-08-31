using System;
using HillClimb.Camera;
using HillClimb.Game;
using HillClimb.UI;
using HillClimb.UI.Screens.GameOverScreen;
using HillClimb.UI.Screens.LevelCompleteScreen;
using UnityEngine;

namespace HillClimb.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private SpawnPoint _spawnPoint;
        [SerializeField] private CharacterData characterData;
        [SerializeField] private Transform _playerContainer;
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private UIManager _uiManager;

        private void Awake()
        {
            LevelEventsManager.LevelReady += OnLevelReady;
            LevelEventsManager.LevelFailed += OnLevelFailed;
            LevelEventsManager.LevelComplete += OnLevelComplete;
            LevelEventsManager.LevelRestart += RestratLevel;
        }

        private void Start()
        {
            _spawnPoint.SetPlayer(characterData, _playerContainer);
            _spawnPoint.SpawnPlayer();
            _cameraFollow.SetTarget(_spawnPoint.Player.transform);
            _cameraFollow.SetFollow(true);
            LevelEventsManager.LevelReady?.Invoke();
        }

        private void OnLevelReady()
        {
            GameStateManager.SetGameState(GameState.Playing);
        }
        
        private void OnLevelFailed()
        {
            GameStateManager.SetGameState(GameState.Ended);
            _uiManager.ShowScreen<GameOverScreen>();
        }

        private void OnLevelComplete()
        {
            GameStateManager.SetGameState(GameState.Ended);
            _uiManager.ShowScreen<LevelCompleteScreen>();
        }

        private void RestratLevel()
        {
            _spawnPoint.SpawnPlayer();
            LevelEventsManager.LevelReady?.Invoke();
        }

        private void OnApplicationQuit()
        {
            LevelEventsManager.LevelReady -= OnLevelReady;
            LevelEventsManager.LevelFailed -= OnLevelFailed;
            LevelEventsManager.LevelRestart -= RestratLevel;
        }
    }
}
