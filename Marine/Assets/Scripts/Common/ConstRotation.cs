using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstRotation : MonoBehaviour
{
    [SerializeField] Vector3 rotationAngle;
    [SerializeField] float rotationsPerMinute;

    private void Update()
    {
        transform.Rotate(new Vector3(
            rotationAngle.x * rotationsPerMinute * Time.deltaTime,
            rotationAngle.y * rotationsPerMinute * Time.deltaTime,
            rotationAngle.z * rotationsPerMinute * Time.deltaTime));
    }
}
