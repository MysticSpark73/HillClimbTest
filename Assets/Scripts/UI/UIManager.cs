using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HillClimb.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<Screen> _screens;

        public Screen ShowScreen<T>() where T : Screen
        {
            var screen = _screens.FirstOrDefault(s => s is T);
            if (screen == null) return null;
            screen.Open();
            return screen;
        }

        public Screen HideScreen<T>() where T : Screen
        {
            var screen = _screens.FirstOrDefault(s => s is T);
            if (screen == null) return null;
            screen.Close();
            return screen;
        }
    }
}