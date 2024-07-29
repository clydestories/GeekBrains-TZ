using UnityEditor;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void OpenMainMenu()
    {
        SceneLoader.LoadScene(SceneName.Menu);
    }
}
