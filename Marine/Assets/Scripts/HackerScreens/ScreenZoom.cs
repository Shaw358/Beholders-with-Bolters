using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zooms in on the screen(s) of the hacker, there are multiple screens so this script needs to keep track of which position the player is facing, and zooms in on the screen
/// </summary>
public class ScreenZoom : MonoBehaviour
{
    [SerializeField] private int currentScreen;
    [SerializeField] private GameObject[] cameraPositions;

    private bool zoomedIn;
    private bool zoomingIn;
    private bool zoomingOut;
    private bool switchingScreen;
    private float speed;
    private float distFromDest;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        speed = .10f;
        currentScreen = 2;
        gameObject.transform.position = cameraPositions[currentScreen-1].transform.position;
    }
    //Note add function to play for smoothzoom + while loop
    
    private void SmoothZoom()
    {
        if (!zoomingIn && !zoomingOut)
        {
            return;
        }
        switch (zoomedIn)
        {
            case false:
                Debug.Log(zoomedIn + " " + currentScreen + " SZ1");
                gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen - 1].transform.position, ref velocity,speed);
                distFromDest = transform.position.z - cameraPositions[currentScreen - 1].transform.position.z;
                if (Mathf.Abs(distFromDest) <= .1f)
                {
                    zoomingIn = false;
                    zoomedIn = true;
                }
                break;
            case true:
                Debug.Log(zoomedIn + " SZ2");
                gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen - 1].transform.position, ref velocity,speed);
                distFromDest = transform.position.z - cameraPositions[currentScreen - 1].transform.position.z;
                if (Mathf.Abs(distFromDest) <= .05f)
                {
                    zoomingOut = false;
                    zoomedIn = false;
                }
                break;
        }
    }
    private void Move()
    {
        if (switchingScreen)
        {
            Debug.Log(switchingScreen + " " + zoomingIn + " " + zoomingOut + " Move");
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, cameraPositions[currentScreen - 1].transform.rotation,speed + .5f);
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen - 1].transform.position, ref velocity, speed);
            distFromDest = transform.rotation.y - cameraPositions[currentScreen - 1].transform.rotation.y;
            if (Mathf.Abs(distFromDest) <= .0001f)
            {
                switchingScreen = false;
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentScreen != 1)
        {
            currentScreen--;
            switchingScreen = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentScreen != 3)
        { 
            currentScreen++;
            switchingScreen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!zoomingIn && !zoomingOut)
            {
                if (zoomedIn)
                {
                    currentScreen -= 3;
                    zoomingOut = true;
                }
                else
                {
                    currentScreen += 3;
                    zoomingIn = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Move();
        SmoothZoom();
    }
}
