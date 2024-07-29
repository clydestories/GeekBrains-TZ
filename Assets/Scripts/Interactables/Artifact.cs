using UnityEngine;

public class Artifact : MonoBehaviour, IInteractable
{
    public void Interact(PlayerTriggerHandler player)
    {
        player.PickUpAtrifact();
        Destroy(gameObject);
    }
}
