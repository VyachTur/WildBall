using UnityEngine;

namespace Scripts.Services.Inputs
{
    public class DesktopInputService : InputService
    {
        public override Vector2 Axis
        { 
            get
            {
                Vector2 axis = SimpleInputAxis();

                return axis == Vector2.zero ? UnityAxis() : axis;
            }
        }

        public static Vector2 UnityAxis() =>
            new Vector2(UnityEngine.Input.GetAxis(Constants.HorizontalAxis),
                        UnityEngine.Input.GetAxis(Constants.VerticalAxis));
    }
}
