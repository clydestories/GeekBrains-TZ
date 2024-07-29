using System;
using UnityEngine;

public class ArtifactInventory : MonoBehaviour
{
    [SerializeField] private int _maxArtifactCount;

    private int _artifactCount = 0;

    public event Action AllArtifactsCollected;

    private void Update()
    {
        if (_artifactCount == _maxArtifactCount)
        {
            AllArtifactsCollected?.Invoke();
        }
    }

    public void AddArtifact()
    {
        _artifactCount++;
    }
}
