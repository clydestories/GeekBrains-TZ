using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    private readonly float _transitionToGameOverDelay = 3;

    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private EnemyTracker _tracker;
    [SerializeField] private Player _player;
    [SerializeField] private ArtifactInventory _artifactInventory;

    private void OnEnable()
    {
        _tracker.AllEnemiesKilled += Win;
        _player.Died += Lose;
        _artifactInventory.AllArtifactsCollected += Win;
    }

    private void OnDisable()
    {
        _tracker.AllEnemiesKilled -= Win;
        _player.Died -= Lose;
        _artifactInventory.AllArtifactsCollected -= Win;
    }

    private void Lose()
    {
        StartCoroutine(TransitToGameOver());
    }

    private void Win()
    {
        Time.timeScale = 0;
        _winScreen.Show();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator TransitToGameOver()
    {
        yield return new WaitForSeconds(_transitionToGameOverDelay);
        SceneLoader.LoadScene(SceneName.GameOver);
    }
}
