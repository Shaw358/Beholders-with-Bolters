using System.Collections;
using UnityEngine;

public class Door : InteractableBase
{
    private bool CanInteract;
    protected override bool canInteract
    {
        get
        {
            canShowInteractButton = false;
            DisableInteractButton();
            return CanInteract;
        }
        set
        {
            CanInteract = value;
        }
    }

    [SerializeField] Animator animator;
    bool isOpen;

    public override void Interact()
    {
        if (!canInteract)
        {
            return;
        }

        if (!isOpen)
        {
            isOpen = true;
            animator.Play("DoorOpening", 0);
        }
        else
        {
            isOpen = false;
            //animator.Play("CloseDoor");
        }
        StartCoroutine(DoorAnimationCoolDown());
    }

    private IEnumerator DoorAnimationCoolDown()
    {
        canInteract = false;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(GetAnimationLength.GetLengthOfAnimation(animator));
        canInteract = true;
    }
}