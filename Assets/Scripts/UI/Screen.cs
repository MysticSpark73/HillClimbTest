using UnityEngine;

namespace HillClimb.UI
{
    public abstract class Screen : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
        protected abstract void OnOpen();
        protected abstract void OnClose();
    }
}