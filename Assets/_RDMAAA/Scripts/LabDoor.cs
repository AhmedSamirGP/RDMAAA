using UnityEngine;

public class LabDoor : InteractableObject
{
    public new void Interact()
    {
        Debug.Log("door interacted");
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 95, 0)), Time.deltaTime * 3f);
        transform.localRotation = Quaternion.LookRotation(new Vector3(0, 95, 0));
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }

}
