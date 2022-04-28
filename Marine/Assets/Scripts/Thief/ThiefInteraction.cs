using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefInteraction : MonoBehaviour
{
    public bool canInteract;
    private InteractableBase currentInteractable;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && currentInteractable)
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagConsts.interactableTag)
        {
            currentInteractable = other.GetComponent<InteractableBase>();
            currentInteractable.EnableInteractButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentInteractable)
        {
            currentInteractable.DisableInteractButton();
            currentInteractable = null;
        }
    }
}
