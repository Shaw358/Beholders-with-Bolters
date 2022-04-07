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
    private bool turning;
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
                gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen + 2].transform.position, ref velocity, speed);
                distFromDest = transform.position.z - cameraPositions[currentScreen + 2].transform.position.z;

                Debug.Log(distFromDest);
                if (Mathf.Abs(distFromDest) <= .1f)
                {
                    zoomingIn = false;
                    zoomedIn = true;
                }
                break;
            case true:
                gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen - 1].transform.position, ref velocity, speed);
                distFromDest = transform.position.z - cameraPositions[currentScreen - 1].transform.position.z;
                Debug.Log(distFromDest);
                if (Mathf.Abs(distFromDest) <= .5f)
                {
                    zoomingOut = false;
                    zoomedIn = false;
                }
                break;
        }
    }
    private void SmoothTurn()
    {
        //Turn to screen
        if (turning == false)
        {
            return;
        }
        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, cameraPositions[currentScreen - 1].transform.rotation.y, transform.rotation.z);

    }
    private void SideMovement()
    {
        if (switchingScreen == false)
        {
            return;
        }
        distFromDest = transform.position.x - cameraPositions[currentScreen - 1].transform.position.x;

        if (Mathf.Abs(distFromDest) <= .3f)
        {
            switchingScreen = false;
        }
        else
        {
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen - 1].transform.position, ref velocity, speed);
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
            Debug.Log("Load1");
            if (!zoomingIn && !zoomingOut)
            {
                Debug.Log("Load2");
                if (zoomedIn)
                {
                    Debug.Log("Load3");
                    zoomingOut = true;
                }
                else
                {
                    Debug.Log("Load4");
                    zoomingIn = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SmoothTurn();
        SideMovement();
        SmoothZoom();
        CheckInput();
    }
}
