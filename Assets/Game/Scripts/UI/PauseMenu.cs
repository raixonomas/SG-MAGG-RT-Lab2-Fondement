using Gameplay.Input;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private SO_InputKey InputPauseMenu;
    [SerializeField] private UnityEvent OnPause;
    [SerializeField] private UnityEvent OnPlay;
    private void Awake()
    {
        InputPauseMenu.EventOnRelease.AddListener(TogglePauseUI);
    }

    public void TogglePauseUI()
    {
        if (!InputManager.Instance.bIsGamePause)
        {
            Pause();
            return;
        }
        Play();
    }
    public void Pause()
    {
        InputManager.Instance.bIsGamePause = true;
        InputManager.Instance.DisableGameplayInput();
        Time.timeScale = 0;
        OnPause.Invoke();
    }
    public void Play()
    {
        InputManager.Instance.bIsGamePause = false; 
        InputManager.Instance.EnableGameplayInput();
        Time.timeScale = 1;
        OnPlay.Invoke();
    }
}