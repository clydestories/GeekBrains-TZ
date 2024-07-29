using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{
    [SerializeField] private ArtifactInventory _artifactInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(this);
        }
    }

    public void PickUpAtrifact()
    {
        _artifactInventory.AddArtifact();
    }
}
