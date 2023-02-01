using UnityEngine;

namespace Scripts.Services.Inputs
{
    public abstract class InputService : IInputService
    {
        public abstract Vector2 Axis { get; }

        public bool IsActivateButtonUp() =>
            SimpleInput.GetButton(Constants.ActivateButton);

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Constants.HorizontalAxis), SimpleInput.GetAxis(Constants.VerticalAxis));
    }
}
