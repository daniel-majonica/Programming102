using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public float MaxStamina = 2;
    public float StaminaDrainRecoveryRate = 0.5f;
    public bool HasStamina { get; private set; }
    public float CurrentStamina { get; private set; }
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();

        CurrentStamina = MaxStamina;
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        if (IsRunning)
        {
            CurrentStamina -= StaminaDrainRecoveryRate * Time.fixedDeltaTime;
            HasStamina = CurrentStamina > 0;
        }
        else 
        {
            CurrentStamina += StaminaDrainRecoveryRate * Time.fixedDeltaTime;
        }
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0, MaxStamina);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning && HasStamina ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }
        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.linearVelocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.linearVelocity.y, targetVelocity.y);
    }
}