using UnityEngine;
using UnityEngine.UI;
using UnityMobileJoystick.Scripts.Core;
using UnityMobileJoystick.Scripts.Extensions;

namespace UnityMobileJoystick.Demo
{
    [RequireComponent(typeof(Text))]
    public class DebugViewDirection : MonoBehaviour
    {
        [SerializeField] private MobileJoystick _joystick;
        
        private Text _text;

        private void UpdateText()
        {
            _text.text = $"{_joystick.Direction} ({_joystick.GetDirectionAngle()})";
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
            
            UpdateText();
        }

        private void OnEnable()
        {
            _joystick.DirectionChanged += UpdateText;
        }

        private void OnDisable()
        {
            _joystick.DirectionChanged -= UpdateText;
        }
    }
}