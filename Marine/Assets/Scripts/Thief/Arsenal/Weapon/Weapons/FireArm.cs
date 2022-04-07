using UnityEngine;

public class FireArm : Weapon
{
    [SerializeField] Camera firepoint;

    public override void Attack()
    {
        RaycastHit hit;
        Physics.Raycast(firepoint.transform.position, firepoint.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity/* NOTE: To be implemented when guards are around, 1 << LayerMask.NameToLayer("Guard")*/);

        Debug.Log(hit.transform.gameObject.name);

        if (hit.transform.TryGetComponent(out Transform name))
        {
            //TODO: Guard stuff
        }
    }
}