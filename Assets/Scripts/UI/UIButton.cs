using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HillClimb.UI
{
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button _button;
        private Action onPointerDownListener;
        private Action onPointerUpListener;
        private bool isPointerDown;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void SetOnPointerDownListener(Action action) => onPointerDownListener = action;

        public void SetInteractable(bool value) => _button.interactable = value;

        public void SetOnPointerUpListener(Action action) => onPointerUpListener = action;

        public void RemoveOnPointerDownListener() => onPointerDownListener = null;

        public void RemoveOnPointerUpListener() => onPointerUpListener = null;

        public void OnPointerDown(PointerEventData eventData) => isPointerDown = true;

        public void OnPointerUp(PointerEventData eventData)
        {
            isPointerDown = false;
            onPointerUpListener?.Invoke();
        }

        private void Update()
        {
            if (isPointerDown)
            {
                onPointerDownListener?.Invoke();
            }
        }
    }
}
