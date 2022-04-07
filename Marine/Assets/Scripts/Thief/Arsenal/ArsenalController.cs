using UnityEngine;

public class ArsenalController : MonoBehaviour
{
    [SerializeField] Arsenal arsenal;

    float fireRateTimer = 0;
    bool canAttack;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            arsenal.UseCurrentWeapon();
            Attack();
        }
        if(Input.GetKey(KeyCode.E))
        {

        }

        //NOTE: fire rate timer
        if (canAttack)
        {
            return;
        }
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > arsenal.GetCUrrentWeaponData().fireRate)
        {
            fireRateTimer = 0;
            canAttack = true;
        }
    }

    public void Attack()
    {
        canAttack = false;
    }

    public void Interact()
    {

    }
}