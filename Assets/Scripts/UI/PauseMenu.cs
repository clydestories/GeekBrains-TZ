using UnityEditor;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private const float PausedTimeScale = 0;
    private const float UnpausedTimeScale = 1;

    [SerializeField] private InputReader _input;
    [SerializeField] private Canvas _pauseMenu;

    private void OnEnable()
    {
        _input.Paused += TogglePause;
    }

    private void OnDisable()
    {
        _input.Paused -= TogglePause;
    }

    public void Unpause()
    {
        Time.timeScale = UnpausedTimeScale;
        _pauseMenu.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    private void Pause()
    {
        Time.timeScale = PausedTimeScale;
        _pauseMenu.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void TogglePause()
    {
        if (_pauseMenu.enabled)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }
}
