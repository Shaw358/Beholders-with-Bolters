using UnityEngine;

public class PickUp : MonoSingleton<PickUp>
{
    [SerializeField] GameObject pickedUpObj;
    public bool isHoldingPickup
    {
        get
        {
            if(pickedUpObj)
            {
                return true;
            }
            return false;
        }
        private set
        {
        }
    }

    private void Update()
    {
        if(!isHoldingPickup)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            pickedUpObj.SetActive(true);
            ClearPickup();
        }
    }

    public void SetPickup(GameObject obj)
    {
        pickedUpObj = obj;
    }

    public void ClearPickup()
    {
        pickedUpObj = null;
    }
}