using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Input
{
    public class InputManager : Manager<InputManager>
    {
        public Dictionary<KeyCode, SO_InputKey> MapOfGameplayInput { get; private set; } = new();

        [SerializeField] private List<SO_InputKey> ListOfGameplayInput;
        [field: SerializeField] public SO_InputKey PauseInput { get; private set; }

        public bool bIsGamePause { get;  set; }

        protected override void Awake()
        {
            base.Awake();
            FeedMapping();
            EnableAllInput();
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

            if (inputAction.type == EventType.KeyUp && inputAction.keyCode == PauseInput.Associativekey)
            {
                PauseInput.OnRelease(inputAction.keyCode);
                return;
            }
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

        public void EnableAllInput()
        {
            PauseInput.SetIsKeyUsable(true);
            foreach (var input in ListOfGameplayInput)
            {
                input.SetIsKeyUsable(true);
            }
        }

        public void DisableAllInput()
        {
            PauseInput.SetIsKeyUsable(false);
            foreach (var input in ListOfGameplayInput)
            {
                input.SetIsKeyUsable(false);
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