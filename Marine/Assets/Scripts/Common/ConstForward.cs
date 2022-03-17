using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstForward : MonoBehaviour
{
    [SerializeField] float speed = 15;
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
