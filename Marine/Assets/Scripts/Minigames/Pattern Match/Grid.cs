using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Vector3 worldpos;
    private GameObject currentButton;
    [SerializeField] private LineRenderer render;

    public void GetLine(GameObject currentButtonNumb)
    {
        currentButton = currentButtonNumb;
    }
    private void Update()
    {
        worldpos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        render.SetPosition(0, worldpos);
        if (currentButton != null)
        {
            Debug.Log(worldpos);
            render.SetPosition(1, currentButton.transform.position);
        }
    }
}
