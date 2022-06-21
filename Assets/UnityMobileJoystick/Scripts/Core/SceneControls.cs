using System;
using UnityEngine;

namespace UnityMobileJoystick.Scripts.Core
{
    public class SceneControls
    {
        public Camera Camera { get; }

        public Canvas Canvas { get; }
        
        public SceneControls(Canvas canvas)
        {
            if (canvas == null)
                throw new ArgumentNullException(nameof(canvas));

            Canvas = canvas;
            
            Camera = canvas.renderMode == RenderMode.ScreenSpaceCamera ? canvas.worldCamera : null;
        }
    }
}