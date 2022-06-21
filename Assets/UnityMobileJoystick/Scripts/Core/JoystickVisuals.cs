using System;
using UnityEngine;

namespace UnityMobileJoystick.Scripts.Core
{
    [Serializable]
    public struct JoystickVisuals
    {
        [SerializeField] private RectTransform _background;

        [SerializeField] private RectTransform _handler;

        public Vector2 BackgroundPosition => _background.position;

        public Vector2 Radius => _background.sizeDelta / 2;
        
        public void SetHandlerAnchoredPosition(Vector2 position)
        {
            _handler.anchoredPosition = position;
        }
        
        public void SetToCenter()
        {
            var center = new Vector2(0.5f, 0.5f);

            _background.pivot = center;

            _handler.anchorMin = center;

            _handler.anchorMax = center;

            _handler.pivot = center;

            _handler.anchoredPosition = Vector2.zero;
        }
    }
}