using System.Collections;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    CameraFeed cameraFeed;
    public bool cameraFeedEnabled { get; private set; }

    [SerializeField] float minRotAngle;
    [SerializeField] float maxRotAngle;
    [SerializeField] float rotationDuration;
    [SerializeField] float rotationBreak;

    bool rotatingClockwise;

    private void Awake()
    {
        cameraFeed = GetComponentInChildren<CameraFeed>();
    }

    public void StartCamera()
    {
        StartCoroutine(Rotator());
    }

    private IEnumerator Rotator()
    {
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