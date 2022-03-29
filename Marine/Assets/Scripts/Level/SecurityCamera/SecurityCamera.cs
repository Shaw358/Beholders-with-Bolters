using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class SecurityCamera : MonoBehaviour
{
    public int cameraID;
    CameraFeed cameraFeed;
    public bool cameraFeedEnabled { get; private set; }

    [SerializeField] float minRotAngle;
    [SerializeField] float maxRotAngle;
    [SerializeField] float rotationDuration;
    [SerializeField] float rotationBreak;

    RaiseEventOptions raiseEventOptions;

    private void Awake()
    {
        raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        cameraFeed = GetComponentInChildren<CameraFeed>();
    }

    public void StartSendingFrameData()
    {
        InvokeRepeating("SendFrameData", 0, .1f);
    }

    public void SendFrameData()
    {
        PhotonNetwork.RaiseEvent(NetworkingIDs.CAMERA_FEED, cameraFeed.GetImageFromCameraAsObject(), raiseEventOptions, SendOptions.SendUnreliable);
    }

    /* NOTE: To be implemented later
    public void ReceiveFrameData(EventData eventData)
    {
        if(eventData.Code == NetworkingIDs.CAMERA_FEED)
        {
            RenderTexture renderTexture = (RenderTexture)eventData.CustomData;
        }
    }
    */

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