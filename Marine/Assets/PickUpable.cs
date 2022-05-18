using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : InteractableBase
{
    public override void Interact()
    {
        PickUp.instance.SetPickup(gameObject);
        gameObject.SetActive(false);
    }
}