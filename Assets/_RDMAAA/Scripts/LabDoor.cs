using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LabDoor : InteractableObject
{
    float timer = 3f;
    public new void Interact()
    {
        if (!canInteract) return;
        StartCoroutine(OpenDoorSlerp());
        // TODO: PLAY SFX
        if (interactionType == InteractionType.Once)
        {
            canInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canInteract) return;
        if (other.CompareTag("Player")) // TODO: check player 2 tag
        {
            Interact();
        }
    }

    IEnumerator OpenDoorSlerp()
    {
        while (timer > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, -95, 0)), Time.deltaTime * 3f);
            yield return new WaitForSeconds(Time.deltaTime);
            timer -= Time.deltaTime;
        }
    }
}
