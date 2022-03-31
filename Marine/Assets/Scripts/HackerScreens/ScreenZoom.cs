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

    private bool zoomedIn = false;
    private bool zoomingIn = false;
    private bool zoomingOut = false;
    private bool switchingScreen = false;
    private float speed;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        speed = .3f;
        currentScreen = 2;
        gameObject.transform.position = cameraPositions[currentScreen-1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchingScreen == true)
        {
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen - 1].transform.position, ref velocity, speed);
            if (gameObject.transform.position == cameraPositions[currentScreen-1].transform.position)
            {
                switchingScreen = false;
            }
        }
        if (zoomingIn == true)
        {
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen + 2].transform.position, ref velocity, speed);
            if (gameObject.transform.position == cameraPositions[currentScreen + 2].transform.position)
            {
                zoomingIn = false;
            }
        }
        if (zoomingOut == true)
        {
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, cameraPositions[currentScreen - 1].transform.position, ref velocity, speed);
            //gameObject.transform.position = Vector3.Lerp(transform.position, cameraPositions[currentScreen - 1].transform.position, speed * Time.deltaTime);
            if (gameObject.transform.position == cameraPositions[currentScreen - 1].transform.position)
            {
                zoomingOut = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) && currentScreen != 1)
        {
            currentScreen--;
            switchingScreen = true;
        }
        else if (Input.GetKeyUp(KeyCode.D) && currentScreen != 3)
        {
            currentScreen++;
            switchingScreen = true;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            if (!zoomedIn)
            {
                zoomingIn = true;
                zoomedIn = true;
            }
            else
            {
                zoomingOut = true;
                zoomedIn = false;
            }
        }
    }
}
