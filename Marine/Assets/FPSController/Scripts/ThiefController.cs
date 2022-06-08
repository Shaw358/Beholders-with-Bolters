///Original script from Unity Forums
using UnityEngine;
using ThiefAnimation;

[RequireComponent(typeof(CharacterController))]
public class ThiefController : MonoSingleton<ThiefController>
{
    [SerializeField] ThiefAnimatonHandler animationHandler;
    [SerializeField] Footsteps thiefFootSounds;

    #region Movement vars
    [SerializeField] float walkingSpeed = 7.5f;
    [SerializeField] float runningSpeed = 11.5f;
    [SerializeField] float gravity = 20.0f;
    [SerializeField] Camera playerCamera;
    [SerializeField] float lookSpeed = 2.0f;
    [SerializeField] float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    bool isRunning;
    public bool canMove = true;
    bool isCrouching;
    bool isMoving = false;
    #endregion

    #region WeaponVars
    [SerializeField] Arsenal arsenal;

    float fireRateTimer = 0;
    bool isReloading;
    bool canAttack;
    bool isShooting { get; set; }
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        canAttack = true;
    }

    void Update()
    {
        if (MultiplayerDataTracker.instance.player == MultiplayerDataTracker.PlayerType.Hacker)
        {
            return;
        }
        #region //Movement Zone\\

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //NOTE: Checks if the character controller is moving 
        if (characterController.velocity.magnitude > .2f)
        {
            isMoving = true;
        }

        isRunning = Input.GetKey(KeyCode.LeftShift);
        //NOTE: The following line prevents the player from running and crouch and the same time
        isCrouching = (isRunning ? true : false) ? false : Input.GetKey(KeyCode.LeftControl);

        if (!isRunning)
        {
            isCrouching = Input.GetKey(KeyCode.LeftControl);
        }

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        #endregion

        #region //Weapon Zone\\
        if (!isReloading && Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
            canAttack = false;
            fireRateTimer = -2;
            arsenal.Reload();
        }

        //FIXME: Yeah updating this every frame is stupid but this will have to do for now
        if (isMoving && isRunning)
        {
            thiefFootSounds.SetNewThreshold(.4f);
            thiefFootSounds.PlayFootStepIfPossible();
        }
        else if (isMoving)
        {
            thiefFootSounds.SetNewThreshold(.7f);
            thiefFootSounds.PlayFootStepIfPossible();
        }

        if (Input.GetKey(KeyCode.Mouse0) && canAttack && arsenal.GetCurrentWeaponData().currentAmmo > 0)
        {
            isShooting = true;
            arsenal.UseCurrentWeapon();
            canAttack = false;
            Attack();
        }

        //NOTE: fire rate timer
        if (!canAttack)
        {
            fireRateTimer += Time.deltaTime;
            if (fireRateTimer > arsenal.GetCurrentWeaponData().fireRate)
            {
                fireRateTimer = 0;
                canAttack = true;
                if (isShooting)
                {
                    isShooting = false;
                }
                if (isReloading)
                {
                    isReloading = false;
                }
            }
        }
        #endregion
    }

    private void LateUpdate()
    {
        #region //animation Zone\\
        if (isRunning && isShooting)
        {
            DoAnimation(ThiefAnimations.ShootingPistol);
            ResetVars();
            return;
        }
        if (isCrouching && isShooting)
        {
            DoAnimation(ThiefAnimations.CrouchingShooting);
            ResetVars();
            return;
        }
        if (isShooting)
        {
            DoAnimation(ThiefAnimations.ShootingPistol);
            ResetVars();
            return;
        }
        if (isRunning)
        {
            DoAnimation(ThiefAnimations.Running);
            ResetVars();
            return;
        }
        if (isCrouching)
        {
            DoAnimation(ThiefAnimations.Crouching);
            ResetVars();
            return;
        }
        if (isMoving)
        {
            DoAnimation(ThiefAnimations.Walking);
            ResetVars();
            return;
        }
        if (!isMoving && isCrouching)
        {
            DoAnimation(ThiefAnimations.CrouchingIdle);
            ResetVars();
            return;
        }
        if (!isMoving)
        {
            DoAnimation(ThiefAnimations.Idle);
            ResetVars();
            return;
        }
        #endregion
    }

    private void ResetVars()
    {
        isMoving = false;
        isCrouching = false;
        isRunning = false;
    }

    public void DoAnimation(ThiefAnimations animation)
    {
        //Debug.Log(animation);
        animationHandler.PlayAnimation(animation);
    }

    public void Attack()
    {
        canAttack = false;
    }

    private void OnDisable()
    {
        arsenal.GetCurrentWeaponData().currentAmmo = 15;
    }
}