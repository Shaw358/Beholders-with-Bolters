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

    [SerializeField] AudioSource source;
    [SerializeField] Animator animator;
    [SerializeField] bool isOpen;

    private void Awake()
    {
        source = GetComponentInParent<AudioSource>();
        animator = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        CanInteract = true;
    }

    public override void Interact()
    {
        if (!canInteract)
        {
            return;
        }

        if (!isOpen)
        {
            isOpen = true;
            animator.Play("OpenDoor", 0);
        }
        else
        {
            isOpen = false;
            animator.Play("CloseDoor", 0);
        }
        source.Play();
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