using Minigames;
using UnityEngine;
using UnityEngine.Events;

public class MinigameTrigger : InteractableBase
{
    [SerializeField] MinigameType type;
    [Header("On succesful minigame completion")]
    [SerializeField] UnityEvent onSuccesfulMinigame;

    private void Start()
    {
        canShowInteractButton = true;
    }

    public override void Interact()
    {
        if(canInteract)
        {
            //TODO: trigger stuff
        }
    }
}