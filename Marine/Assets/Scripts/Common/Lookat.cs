using UnityEngine;

/// <summary>
/// Small script to always look at a certain object
/// </summary>

public class Lookat : MonoBehaviour
{
    [SerializeField] GameObject lookatTarget;

    private void Update()
    {
        if (lookatTarget)
            transform.LookAt(lookatTarget.transform);
        //mandatory correction
        transform.Rotate(0, 180, 0);
    }
}