using HillClimb.Core;
using UnityEngine;

namespace HillClimb.Level
{
    public class LevelFinish : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Parameters.PlayerTag))
            {
                LevelEventsManager.LevelComplete?.Invoke();
            }
        }
    }
}
