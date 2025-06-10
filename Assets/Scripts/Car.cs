using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text kmhText;
    [SerializeField] private TMPro.TMP_Text mphText;
    [SerializeField] private Rigidbody carRigidbody;
    [SerializeField] private Transform floor;
    [SerializeField] private ATireSetBase tireSet;
    [SerializeField] private float motorTorque = 400;
    [SerializeField] private float maxSteerAngle = 30f;
    [SerializeField] private float brakePower = 2f;

    
    // Initialize
    private void Awake()
    {
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }


    // Update
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 playerInput = context.ReadValue<Vector2>();
        float verticalInput = playerInput.y;
        float horizontalInput = playerInput.x;

        DoAccelerate(verticalInput);
        DoSteer(horizontalInput);
    }
    
    public void OnBrakeInput(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                DoBrake(brakePower);
            break;

            case InputActionPhase.Canceled:
                DoBrake(0f);
            break;
        }
    }

    private void DoBrake(float value)
    {
        foreach (var brakerTire in tireSet.brakerTires)
            brakerTire.WheelCollider.brakeTorque = Mathf.Abs(brakerTire.WheelCollider.rpm) * value;
    }

    private void DoSteer(float horizontalInput)
    {
        foreach (var steererTire in tireSet.steererWheels)
            steererTire.WheelCollider.steerAngle = horizontalInput * maxSteerAngle;
    }

    private void DoAccelerate(float verticalInput)
    {
        foreach (var acceleraterTire in tireSet.acceleraterTires)
            acceleraterTire.WheelCollider.motorTorque = verticalInput * motorTorque;
    }

    private void Update()
    {
        foreach (var tire in tireSet.tires)
            tire.ApplyLocalPositionToVisuals();
        
        kmhText.text = $"KM/H: {(int)GetSpeedInKMH()}";
        mphText.text = $"M/H: {(int)GetSpeedInMPH()}";
        
        Vector3 newFloorFollowPosition = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        floor.position = newFloorFollowPosition;
    }

    public float GetSpeedInKMH()
    {
        return carRigidbody.velocity.magnitude * 3.6f;
	}

    public float GetSpeedInMPH()
    {
        return carRigidbody.velocity.magnitude * 2.237f;
    }

    // Dispose
}
