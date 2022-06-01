using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActives : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects = new List<GameObject>();

    public void ActivateObjects()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(true);
        }
    }

    public void DeactivateObjects()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }
}
