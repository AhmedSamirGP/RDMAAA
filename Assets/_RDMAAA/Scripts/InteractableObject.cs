using UnityEngine;

public enum InteractionType
{
    SphereCollider,
    BoxCollider
}

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    protected float interactionRadius = 3f;
    [SerializeField]
    protected bool drawInteraction = true;
    [SerializeField]
    protected InteractionType interactionType = InteractionType.SphereCollider;

    void Start()
    {
        Debug.Log("InteractableObject start");
        switch (interactionType)
        {
            case InteractionType.SphereCollider:
                var interactionSphere = gameObject.AddComponent<SphereCollider>();
                interactionSphere.radius = interactionRadius;
                interactionSphere.isTrigger = true;
                break;
            case InteractionType.BoxCollider:
                var interactionBox = gameObject.AddComponent<BoxCollider>();
                interactionBox.size = Vector3.one * interactionRadius;
                interactionBox.isTrigger = true;
                break;
        }
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    private void OnDrawGizmosSelected()
    {
        if (!drawInteraction) return;

        Gizmos.color = Color.blue;
        switch (interactionType)
        {
            case InteractionType.SphereCollider:
                Gizmos.DrawWireSphere(transform.position, interactionRadius);
                break;
            case InteractionType.BoxCollider:
                Gizmos.DrawWireCube(transform.position, Vector3.one * interactionRadius);
                break;
        }
    }

}
