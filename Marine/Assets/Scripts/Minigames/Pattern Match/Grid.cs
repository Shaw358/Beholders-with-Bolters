using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private LineRenderer renderer;
    private Vector3 worldpos;
    public void GetLine(int pointInt)
    {
        //Draw a line every frame between the pressed button and the cursor.
        renderer.SetPosition(1, transform.position);
        renderer.SetPosition(2, worldpos);
        renderer.endWidth = 500;
        renderer.startWidth = 500;

        Debug.Log("The point number " + pointInt + " has been pressed");
    }
    private void Update()
    {
        worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
