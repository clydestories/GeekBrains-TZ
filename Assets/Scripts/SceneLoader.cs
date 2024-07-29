using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}

public enum SceneName
{
    Menu,
    Game,
    GameOver
}
