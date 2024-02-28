using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Gameplay.Input
{
    public class InputManager : Manager<InputManager>
    {
        public Dictionary<KeyCode, SO_InputKey> MapOfGameplayInput { get; private set; } = new();

        [SerializeField] private List<SO_InputKey> ListOfGameplayInput;
        [field: SerializeField] public SO_InputKey PauseInput { get; private set; }

        public bool bIsGamePause { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            FeedMapping();
            PauseInput.EventOnPress.AddListener(ToggleGameplayInput);
        }

        private void OnGUI()
        {
            UpdateInput();
        }

        private void FeedMapping()
        {
            foreach (var input in ListOfGameplayInput)
            {
                MapOfGameplayInput.Add(input.Associativekey, input);
            }
        }

        private void UpdateInput()
        {
            Event inputAction = Event.current;
            foreach (var input in ListOfGameplayInput)
            {
                if (inputAction.type == EventType.KeyDown)
                {
                    input.OnPress(inputAction.keyCode);
                }
                else if (inputAction.type == EventType.KeyUp)
                {
                    input.OnRelease(inputAction.keyCode);
                }
            }
        }

        private void ToggleGameplayInput()
        {
            foreach (var input in ListOfGameplayInput)
            {
                input.SetIsKeyUsable(!bIsGamePause);
            }
        }

        public void EnableGameplayInput()
        {
            if (bIsGamePause)
            {
                return;
            }
            foreach (var input in ListOfGameplayInput)
            {
                input.SetIsKeyUsable(true);
            }
        }

        public void DisableGameplayInput()
        {
            foreach (var input in ListOfGameplayInput)
            {
                input.SetIsKeyUsable(false);
            }
        }
    }
}
