using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    protected virtual bool canInteract { get; set; }
    [SerializeField] private GameObject[] InteractVisualFeedback;
    [SerializeField] protected bool canShowInteractButton;

    public virtual void Interact()
    {
    }

    public void EnableInteractButton()
    {
        if (!canShowInteractButton)
        {
            return;
        }
        foreach (GameObject item in InteractVisualFeedback)
        {
            item.SetActive(true);
        }

    }

    public void DisableInteractButton()
    {
        foreach (GameObject item in InteractVisualFeedback)
        {
            item.SetActive(false);
        }
    }
}