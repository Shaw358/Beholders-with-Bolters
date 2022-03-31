using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] Rigidbody m_Rigidbody;
    [SerializeField] private float m_Speed;

    [SerializeField] private bool CanMove;

    private void FixedUpdate()
    {
        if (CanMove)
        {
            m_Rigidbody.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * .1f) + (transform.right * Input.GetAxis("Horizontal") * .1f));
            
            if (Input.GetKeyDown("space"))
            {
                m_Rigidbody.AddForce(transform.up * 1);
            }
        }
    }
}
