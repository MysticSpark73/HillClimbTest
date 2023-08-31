using HillClimb.Level;
using UnityEngine;
using UnityEngine.UI;

namespace HillClimb.UI.Screens.GameOverScreen
{
    public class GameOverScreen : Screen
    {
        [SerializeField] private Button _restartButton;
        
        public override void Open()
        {
            gameObject.SetActive(true);
            OnOpen();
        }

        public override void Close()
        {
            OnClose();
            gameObject.SetActive(false);
        }

        protected override void OnOpen()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        protected override void OnClose()
        {
            _restartButton.onClick.RemoveAllListeners();
        }

        private void Restart()
        {
            Close();
            LevelEventsManager.LevelRestart?.Invoke();
        }
    }
}