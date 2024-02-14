using UnityEngine;

namespace Gameplay.Input
{
    public class InputSample : MonoBehaviour
    {
        public SO_InputKey DesiredAction;

        /// <summary>
        /// Update are handle Inside InputManager
        /// </summary>
        private void OnEnable()
        {
            DesiredAction.EventOnPress.AddListener(PressKey);
            DesiredAction.EventOnRelease.AddListener(ReleaseKey);
        }

        private void OnDisable()
        {
            DesiredAction.EventOnPress.RemoveListener(PressKey);
            DesiredAction.EventOnRelease.RemoveListener(ReleaseKey);
        }

        private void PressKey()
        {
            print("Press");
        }

        private void ReleaseKey()
        {
            print("Release");
        }

        private void ReleaseKey2()
        {
            print("Bitch");
        }
    }
}