using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMov : MonoBehaviour
{
    public Joystick movementJoystick;
    public Joystick cameraJoystick;
    public float movementSpeed = 10f;
    public float rotationSpeed = 100f;
    public float currentBattery;
    public Transform cameraTransform;
    public BatteryPool batteryPool;
    public Linterna LinMAXlc;

    private float cameraPitch = 0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        currentBattery = LinMAXlc.energia_Actual;
    }

    private void Update()
    {
        
        float horizontal = movementJoystick.Horizontal;
        float vertical = movementJoystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = cameraTransform.forward * direction.z + cameraTransform.right * direction.x;
            moveDirection.y = 0;
            rb.MovePosition(rb.position + moveDirection * movementSpeed * Time.deltaTime);
        }

        
        float lookHorizontal = cameraJoystick.Horizontal;
        float lookVertical = cameraJoystick.Vertical;

        
        transform.Rotate(Vector3.up * lookHorizontal * rotationSpeed * Time.deltaTime);

        
        cameraPitch -= lookVertical * rotationSpeed * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, -45f, 45f); 

        cameraTransform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            currentBattery = Mathf.Clamp(currentBattery + 20f, 0, LinMAXlc.energia_Actual);
            other.gameObject.SetActive(false);
            batteryPool.ReactivateBattery(other.gameObject);
        }
    }
}

