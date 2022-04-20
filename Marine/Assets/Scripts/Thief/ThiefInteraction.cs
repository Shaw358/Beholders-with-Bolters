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
        Debug.Log("Why");
        if (other.gameObject.tag == TagConsts.interactableTag)
        {
            Debug.Log("Why2");
            currentInteractable = other.GetComponent<InteractableBase>();
            currentInteractable.EnableInteractButton();
            Debug.Log(currentInteractable.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentInteractable)
        {
            Debug.Log(currentInteractable.gameObject.name);
            currentInteractable.DisableInteractButton();
            currentInteractable = null;
        }
    }
}
