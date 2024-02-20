using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Input
{
    [CreateAssetMenu(fileName = "LeftPaddle", menuName = "ScriptableObjects/InputKey", order = 1)]
    public class SO_InputKey : ScriptableObject, IHandleInput
    {
        [field: SerializeField] public UnityEvent EventOnPress { get; private set; }
        [field: SerializeField] public UnityEvent EventOnRelease { get; private set; }

        [field: SerializeField] public bool bIsKeyUsable { get; set; } = true;
        [SerializeField] public KeyCode Associativekey;
       
        [field: SerializeField] public bool IsKeyPress { get;  private set; }
        
        public virtual void OnPress(KeyCode key)
        {
            if (!IsUpdateUsable(key)) return;
            IsKeyPress = true;
            EventOnPress.Invoke();
        }

        public virtual void OnRelease(KeyCode key)
        {
            if (!IsUpdateUsable(key)) return;
            IsKeyPress = false;
            EventOnRelease.Invoke();
        }

        private bool IsUpdateUsable(KeyCode key)
        {
            return bIsKeyUsable && Associativekey == key;
        }
        
        private void OnDisable()
        {
            EventOnPress.RemoveAllListeners();
            EventOnRelease.RemoveAllListeners();
        }
    }
}