using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    protected virtual bool canInteract { get; set; }
    [SerializeField] private GameObject InteractVisualFeedback;
    [SerializeField] protected bool canShowInteractButton;

    public virtual void Interact()
    {
    }

    public void EnableInteractButton()
    {
        if (canShowInteractButton)
            InteractVisualFeedback.SetActive(true);
    }

    public void DisableInteractButton()
    {
        InteractVisualFeedback.SetActive(false);
    }
}