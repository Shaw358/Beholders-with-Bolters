using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrawerInteractable : InteractableBase
{
    [SerializeField] GameObject releasableCode;
    [SerializeField] Animator animator;

    [SerializeField] UnityEvent action;

    private void Start()
    {
        TurnOnCanInteract();
    }

    public override void Interact()
    {
        if(!canInteract)
        {
            return;
        }
        canShowInteractButton = false;
        TurnOffCanInteract();

        animator.Play("OpenDrawer", 0);

        if(releasableCode)
        {
            releasableCode.SetActive(true);
        }

        action?.Invoke();
    }
}
