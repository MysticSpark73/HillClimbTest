using HillClimb.Level;
using UnityEngine;
using UnityEngine.UI;

namespace HillClimb.UI.Screens.LevelCompleteScreen
{
    public class LevelCompleteScreen : Screen
    {
        [SerializeField] private Button _reloadButton;
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
            _reloadButton.onClick.AddListener(ReloadLevel);
        }

        protected override void OnClose()
        {
            _reloadButton.onClick.RemoveAllListeners();
        }

        private void ReloadLevel()
        {
            Close();
            LevelEventsManager.LevelRestart?.Invoke();
        }
    }
}