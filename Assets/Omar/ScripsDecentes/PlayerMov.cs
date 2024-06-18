using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Joystick movementJoystick;
    public Joystick cameraJoystick;
    public float movementSpeed = 10f;
    public float rotationSpeed = 100f;
    public Transform cameraTransform;

    private float cameraPitch = 0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze rotation on all axes
    }

    private void Update()
    {
        // Movimiento del jugador
        float horizontal = movementJoystick.Horizontal;
        float vertical = movementJoystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = cameraTransform.forward * direction.z + cameraTransform.right * direction.x;
            moveDirection.y = 0;
            rb.MovePosition(rb.position + moveDirection * movementSpeed * Time.deltaTime);
        }

        // Rotaci�n de la c�mara
        float lookHorizontal = cameraJoystick.Horizontal;
        float lookVertical = cameraJoystick.Vertical;

        // Rotar el jugador en el eje Y (girar la c�mara de lado a lado)
        transform.Rotate(Vector3.up * lookHorizontal * rotationSpeed * Time.deltaTime);

        // Ajustar el pitch de la c�mara (girar la c�mara hacia arriba y hacia abajo)
        cameraPitch -= lookVertical * rotationSpeed * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, -45f, 45f); // Limitar el �ngulo de la c�mara

        cameraTransform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
    }
}

