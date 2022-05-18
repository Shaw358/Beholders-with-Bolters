using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class SecurityCamera : MonoBehaviour
{
    public int cameraID;
    [SerializeField] CameraFeed cameraFeed;
    public bool cameraFeedEnabled { get; private set; }

    [SerializeField] float minRotAngle;
    [SerializeField] float maxRotAngle;
    [SerializeField] float rotationDuration;
    [SerializeField] float rotationBreak;

    RaiseEventOptions raiseEventOptions;

    //--------------

    [Header("Networking")]
    [SerializeField] float cameraUpdateTime;
    float timer;

    [SerializeField] UpdateScreen screen;

    //--------------

    private void Awake()
    {
        raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
    }
    
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > cameraUpdateTime)
        {
            SendFrameData();
            timer = 0;
        }
    }

    public void SendFrameData()
    {
        PhotonNetwork.RaiseEvent(NetworkingIDs.CAMERA_FEED, cameraFeed.GetImageFromCameraAsObject(), raiseEventOptions, SendOptions.SendUnreliable);
    }

    public void StartCameraRotator()
    {
        StartCoroutine(Rotator());
    }

    private IEnumerator Rotator()
    {
        bool rotatingClockwise = false;

        float startRot = 0;
        float targetRot = 0;

        float elapsedTime = 0;

        while (true)
        {
            while (elapsedTime >= rotationDuration)
            {
                transform.eulerAngles = new Vector3(Mathf.Lerp(startRot, targetRot, elapsedTime / rotationDuration), transform.eulerAngles.y, transform.eulerAngles.z);
                elapsedTime += Time.deltaTime;

                yield return null;
            }
            elapsedTime = 0;

            yield return new WaitForSeconds(rotationBreak);

            if(rotatingClockwise)
            {
                startRot = minRotAngle;
                targetRot = maxRotAngle;
            }
            else
            {
                startRot = maxRotAngle;
                targetRot = minRotAngle;
            }
        }
    }
}