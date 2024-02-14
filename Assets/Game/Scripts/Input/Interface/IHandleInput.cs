using UnityEngine;

namespace Gameplay.Input
{
    public interface IHandleInput
    {
        public void OnPress(KeyCode key);
        public void OnRelease(KeyCode key);
    }
}