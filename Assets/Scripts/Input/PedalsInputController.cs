using HillClimb.Game;
using HillClimb.UI;
using UnityEngine;

namespace HillClimb.Input
{
    public class PedalsInputController : MonoBehaviour
    {
        [SerializeField] private UIButton pedalGas;
        [SerializeField] private UIButton pedalBreak;

        private void Awake()
        {
            GameStateManager.GameStateChanged += OnGameStateChanged;
            pedalGas.SetOnPointerDownListener(OnGasPressed);
            pedalBreak.SetOnPointerDownListener(OnBreakPressed);
            pedalGas.SetOnPointerUpListener(OnGasReleased);
            pedalBreak.SetOnPointerUpListener(OnBreakReleased);
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameStateManager.GameState.Equals(GameState.Playing)) return;
            
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow)) OnGasPressed();
            else if (UnityEngine.Input.GetKeyUp(KeyCode.RightArrow)) OnGasReleased();
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow)) OnBreakPressed();
            else if (UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow)) OnBreakReleased();
        }

        private void OnGasPressed()
        {
            InputEventsManager.GasPedalPressed?.Invoke(true);
        }

        private void OnGasReleased()
        {
            InputEventsManager.GasPedalPressed?.Invoke(false);
        }

        private void OnBreakPressed()
        {
            InputEventsManager.BreakPedalPressed?.Invoke(true);
        }

        private void OnBreakReleased()
        {
            InputEventsManager.BreakPedalPressed?.Invoke(false);
        }

        private void OnGameStateChanged(GameState newState)
        {
            pedalGas.SetInteractable(newState.Equals(GameState.Playing));
            pedalBreak.SetInteractable(newState.Equals(GameState.Playing));
        }
    }
}
