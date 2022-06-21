using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityMobileJoystick.Scripts.Core
{
    public sealed class MobileJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private JoystickVisuals _visuals;

        private SceneControls _sceneControls;

        public Vector2 Direction { get; private set; }

        public Vector2 Center =>
            RectTransformUtility.WorldToScreenPoint(_sceneControls.Camera, _visuals.BackgroundPosition); 

        public event Action DirectionChanged;

        private void Start()
        {
            _sceneControls = new SceneControls(GetComponentInParent<Canvas>());

            _visuals.SetToCenter();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pointerOffset = eventData.position - Center;

            Vector2 rawDirection = pointerOffset / (_visuals.Radius * _sceneControls.Canvas.scaleFactor);
            
            Direction = Vector2.ClampMagnitude(rawDirection, 1);

            _visuals.SetHandlerAnchoredPosition(Direction * _visuals.Radius);

            DirectionChanged?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Direction = Vector2.zero;

            _visuals.SetHandlerAnchoredPosition(Vector2.zero);

            DirectionChanged?.Invoke();
        }
    }
}