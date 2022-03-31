using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public GameObject _cam;
    public GameObject _Player;

    public bool canMove;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (canMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -85, 85);

            _Player.transform.eulerAngles = new Vector3(0, yRotation, 0.0f);
            _cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        }
    }

    public void LockMovement(bool lockBool)
    {
        if (lockBool)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            canMove = true;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            canMove = false;
        }
    }

    public void DirectCameraToTarget(Transform target)
    {
        StartCoroutine(DirectCameraNumerator());
    }

    private IEnumerator DirectCameraNumerator()
    {
        yield return null;
    }
}