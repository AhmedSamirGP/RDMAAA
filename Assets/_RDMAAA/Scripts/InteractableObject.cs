using UnityEngine;

public enum InteractionType
{
    Once,
    Multiple
}

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    protected InteractionType interactionType;
    [SerializeField]
    protected bool canInteract = true;

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

}
