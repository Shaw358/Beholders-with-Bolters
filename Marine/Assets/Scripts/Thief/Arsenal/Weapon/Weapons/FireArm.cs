using UnityEngine;

public class FireArm : Weapon
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource weaponSFX;
    [SerializeField] ParticleSystem muzzleEffect;
    [SerializeField] Camera firepoint;

    public override void Attack()
    {
        RaycastHit hit;
        Physics.Raycast(firepoint.transform.position, firepoint.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);

        muzzleEffect.Play();
        weaponSFX.PlayOneShot(clips[0]);
        try
        {
            Debug.Log("1");
            if (hit.transform.TryGetComponent(out SecurityGuard name))
            {
                Debug.Log("2");
                name.DecreaseHealth(50);
            }
        }
        catch
        {
            Debug.Log("No bullets fly");
        }
    }

    public override void PlayReloadSFX()
    {
        weaponSFX.PlayOneShot(clips[1]);
    }
}