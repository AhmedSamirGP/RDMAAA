using UnityEngine;

public class LaserButton : InteractableObject
{

    [SerializeField]
    PeriodicEnemy script;
    [SerializeField]
    GameObject laser;

    public new void Interact()
    {
        if (!canInteract) return;
        if (interactionType == InteractionType.Once)
        {
            canInteract = false;
        }
        Destroy(laser);

        if (script != null)
        {
            script.active = false;
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        else
        {
            Debug.LogError("Script periodic enemy not found!!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canInteract) return;
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }
}
