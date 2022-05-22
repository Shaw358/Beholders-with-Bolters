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
    [SerializeField] public bool isActive;

    RaiseEventOptions raiseEventOptions;

    //--------------

    [Header("Networking")]
    [SerializeField] float cameraUpdateTime;
    float timer;

    //--------------

    private void Awake()
    {
        raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
    }

    private void Start()
    {
        StartCoroutine(Rotator());
    }

    private void Update()
    {
        if(!isActive)
        {
            return;
        }
        SendFrameData();

        //timer += Time.deltaTime;
        //if (timer > cameraUpdateTime)
        //{
         //   timer = 0;
        //}
    }

    public void SendFrameData()
    {
        Debug.Log("bruh");
        PhotonNetwork.RaiseEvent(NetworkingIDs.CAMERA_FEED, cameraFeed.GetImageFromCameraAsObject(), raiseEventOptions, SendOptions.SendUnreliable);
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
}