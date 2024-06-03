using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojugador : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick rotateJoystick;

    private Vector3 moveDirection;
    private Vector2 currentRotation;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float moveX = moveJoystick.Horizontal + Input.GetAxis("Horizontal");
        float moveY = moveJoystick.Vertical + Input.GetAxis("Vertical");

        Vector3 forwardMovement = transform.forward * moveY;
        Vector3 rightMovement = transform.right * moveX;

        moveDirection = (forwardMovement + rightMovement).normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        float rotateX = rotateJoystick.Horizontal;
        float rotateY = rotateJoystick.Vertical;

        // Calcular la nueva rotación con límites verticales
        currentRotation.x = Mathf.Clamp(currentRotation.x - rotateY * rotationSpeed * Time.deltaTime, -40f, 40f);
        currentRotation.y += rotateX * rotationSpeed * Time.deltaTime;

        // Aplicar la rotación al objeto
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
    }
}
