using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class SecurityCamera : MonoBehaviour
{
    public int cameraID;
    [SerializeField] public CameraFeed cameraFeed;
    public bool cameraFeedEnabled { get; private set; }

    [SerializeField] float minRotAngle;
    [SerializeField] float maxRotAngle;
    [SerializeField] float rotationDuration;
    [SerializeField] public bool isActive;

    private void Start()
    {
        StartCoroutine(Rotator());
    }

    public void StartCameraRotator()
    {
        StartCoroutine(Rotator());
    }

    private IEnumerator Rotator()
    {
        bool rotatingClockwise = false;

        float startRot = minRotAngle;
        float targetRot = maxRotAngle;

        float elapsedTime = 0;

        while (true)
        {
            while (elapsedTime <= rotationDuration)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(startRot, targetRot, elapsedTime / rotationDuration), transform.eulerAngles.z);
                elapsedTime += Time.deltaTime;

                if (elapsedTime >= rotationDuration)
                {
                    elapsedTime = 0;
                    if (rotatingClockwise)
                    {
                        startRot = minRotAngle;
                        targetRot = maxRotAngle;
                        rotatingClockwise = false;
                    }
                    else
                    {
                        startRot = maxRotAngle;
                        targetRot = minRotAngle;
                        rotatingClockwise = true;
                    }
                }
                yield return null;
            }
            yield return null;
        }
    }

    public void ActivateCamera()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    
    public void DeactivateCamera()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}