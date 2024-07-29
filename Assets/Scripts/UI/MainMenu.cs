using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.LoadScene(SceneName.Game);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
